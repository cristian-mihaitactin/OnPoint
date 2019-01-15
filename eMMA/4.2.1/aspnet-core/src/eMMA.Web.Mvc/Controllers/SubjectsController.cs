using System;
using System.Collections.Generic;
using System.Linq;
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
using eMMA.Uni.Students;

namespace eMMA.Web.Controllers
{
    [AbpMvcAuthorize]
    public class SubjectsController : eMMAControllerBase
    {
        private readonly IUniSubjectAppService _subjectsAppService;
        //private readonly IUserAppService _userAppService;
        private readonly IProfessorAppService _professorAppService;
        private readonly IStudentAppService _studentAppService;


        public SubjectsController(IUniSubjectAppService subjectsAppService,
            IProfessorAppService professorAppService
            , IStudentAppService studentAppService)
        {
            _subjectsAppService = subjectsAppService;
            _professorAppService = professorAppService;
            _studentAppService = studentAppService;
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

        public async Task<ActionResult> MySubjects()
        {
            //get user
            var userId = User.Identity.GetUserId();

            if (!userId.HasValue)
            {
                throw new Exception("User not found.");
            }

            List<UniSubjectDto> subjList = new List<UniSubjectDto>();

            if (User.IsInRole("Professor"))
            {
                var prof = await _professorAppService.GetProfessorUserByAuthUserIdAsync(userId.Value);
                var profSubjList = prof.ObjectList.ToList();
                foreach (var professorUniSubjectse in profSubjList)
                {
                    var subject = await _subjectsAppService.GetSubjectByIdAsync(professorUniSubjectse.UniSubjectId);
                    subjList.Add(ObjectMapper.Map<UniSubjectDto>(subject));
                }
            }
            else
            {
                if (User.IsInRole("Student"))
                {
                    var stud = await _studentAppService.GetStudentUserByAuthUserIdAsync(userId.Value);
                    var studSubjList = stud.ObjectList.ToList();

                    foreach (var professorUniSubjectse in studSubjList)
                    {
                        var subject = await _subjectsAppService.GetSubjectByIdAsync(professorUniSubjectse.UniSubjectId);
                        subjList.Add(ObjectMapper.Map<UniSubjectDto>(subject));
                    }
                }
            }

            return View("MySubjects", new MySubjectViewModel(subjList));
        }
        //public async Task<UniSubjectEditViewModel> Update(UniSubjectEditViewModel subject)
        //{
        //    var subjectResult = _subjectsAppService.Update(subject.GetDto());

        //    return new UniSubjectEditViewModel(subjectResult);
        //}
        public async Task<ActionResult> Details(Guid uniSubjectId)
        {
            var subject = (await _subjectsAppService.GetSubjectByIdAsync(uniSubjectId));
            var subjectDto = ObjectMapper.Map<UniSubjectDto>(subject);
            var model = new UniSubjectViewModel(subjectDto);

            return View(model);
        }

        public async Task<ActionResult> AddInstancePop(Guid subjectId)
        {
            var userId = User.Identity.GetUserId();
            var prof = await _professorAppService.GetProfessorUserByAuthUserIdAsync(userId.Value);

            var model = new CreateSubjectInstanceModel()
            {
                SubjectId = subjectId,
                ProfId = prof.Id
            };

            //return View("_AddSubjectInstanceModal", model);
            return View("_AddInstanceModal", model);
        }
    }
}