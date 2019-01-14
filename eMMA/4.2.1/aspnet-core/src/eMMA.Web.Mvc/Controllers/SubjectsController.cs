using System;
using System.Collections.Generic;
using Abp.AspNetCore.Mvc.Authorization;
using eMMA.Controllers;
using eMMA.Uni.UniSubject;
using eMMA.Web.Models.UniSubjects;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Security;
using eMMA.Uni.UniSubject.Dto;
using eMMA.Users;
using eMMA.Entities;
using eMMA.Uni.Professor;
using eMMA.Uni.Professor.Dto;

namespace eMMA.Web.Controllers
{
    [AbpMvcAuthorize]
    public class SubjectsController : eMMAControllerBase
    {
        private readonly IUniSubjectAppService _subjectsAppService;
        //private readonly IUserAppService _userAppService;
        private readonly IProfessorAppService _professorAppService;


        public SubjectsController(IUniSubjectAppService subjectsAppService,
            IProfessorAppService professorAppService)
        {
            _subjectsAppService = subjectsAppService;
            _professorAppService = professorAppService;
        }
        public async Task<ActionResult> Index()
        {
            var subjects = (await _subjectsAppService.GetAllUniSubjects()).Items;

            var modelSubjects =  new List<UniSubjectListEntityViewModel>();

            foreach (var subject in subjects)
            {
                var subjectModel = new UniSubjectListEntityViewModel()
                {
                    Id = subject.Id,
                    Title = subject.Title,
                    Credits = subject.Credits,
                    CourseCount = subject.Courses.Count,
                    LabsCount = subject.Labs.Count,
                    SeminarCount = subject.Seminars.Count
                };

                modelSubjects.Add(subjectModel);
            }
            var model = new UniSubjectListViewModel
            {
                UniSubjects = modelSubjects
            };
            return View(model);
        }

        public async Task<ActionResult> EditSubjectModal(Guid subjectId)
        {
            var subject = await _subjectsAppService.GetSubjectByIdAsync(subjectId);//_userAppService.Get(new EntityDto<long>(userId));
            var subjectDto = ObjectMapper.Map<UniSubjectDto>(subject);
            var subjectVM = new UniSubjectViewModel(subjectDto);

            return View("_EditSubjectModal", subjectVM);
        }

        //TODO
        public async void AssingSubject(Guid subjectId)
        {
            var userId = User.Identity.GetUserId();

            if (!userId.HasValue)
            {
                throw new Exception("User not found.");
            }

            var subject = await _subjectsAppService.GetSubjectByIdAsync(subjectId);

            var prof = await _professorAppService.GetProfessorUserByAuthUserIdAsync(userId.Value);


            var profSub = new ProfessorUniSubjects()
            {
                Professor = prof,
                ProfessorId = prof.Id,
                UniSubject = subject,
                UniSubjectId = subjectId
            };

            prof.ObjectList.Add(profSub);
            subject.Professors.Add(profSub);

            var dto = ObjectMapper.Map<UniSubjectDto>(subject);
            var profDto = ObjectMapper.Map < ProfessorDto>(prof);
            //_subjectsAppService.Update(dto);
            _professorAppService.UpdateSync(profDto);

        }
        //public async Task<UniSubjectEditViewModel> Update(UniSubjectEditViewModel subject)
        //{
        //    var subjectResult = _subjectsAppService.Update(subject.GetDto());

        //    return new UniSubjectEditViewModel(subjectResult);
        //}
    }
}