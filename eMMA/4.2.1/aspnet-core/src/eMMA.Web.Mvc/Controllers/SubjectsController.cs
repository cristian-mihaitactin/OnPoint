using System;
using System.Collections.Generic;
using Abp.AspNetCore.Mvc.Authorization;
using eMMA.Controllers;
using eMMA.Uni.UniSubject;
using eMMA.Web.Models.UniSubjects;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using eMMA.Uni.UniSubject.Dto;

namespace eMMA.Web.Controllers
{
    [AbpMvcAuthorize]
    public class SubjectsController : eMMAControllerBase
    {
        private readonly IUniSubjectAppService _subjectsAppService;

        public SubjectsController(IUniSubjectAppService subjectsAppService)
        {
            _subjectsAppService = subjectsAppService;
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

        //public async Task<UniSubjectEditViewModel> Update(UniSubjectEditViewModel subject)
        //{
        //    var subjectResult = _subjectsAppService.Update(subject.GetDto());

        //    return new UniSubjectEditViewModel(subjectResult);
        //}
    }
}