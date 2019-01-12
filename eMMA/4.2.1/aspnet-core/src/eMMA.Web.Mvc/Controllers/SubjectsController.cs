using System;
using Abp.AspNetCore.Mvc.Authorization;
using eMMA.Controllers;
using eMMA.Uni.UniSubject;
using eMMA.Web.Models.UniSubjects;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            var model = new UniSubjectListViewModel()
            {
                UniSubjects = subjects
            };
            return View(model);
        }
        public async Task<ActionResult> Details(Guid uniSubjectId)
        {
            var subject = (await _subjectsAppService.GetSubjectByIdAsync(uniSubjectId));
            var model = ObjectMapper.Map<UniSubjectDetailsViewModel>(subject);
            return View(model);
        }
    }
}