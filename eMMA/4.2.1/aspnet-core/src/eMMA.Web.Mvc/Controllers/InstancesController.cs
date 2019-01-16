using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Runtime.Security;
using eMMA.Controllers;
using eMMA.Entities;
using eMMA.Uni.Instances;
using eMMA.Uni.Instances.Dto;
using eMMA.Uni.Professor;
using eMMA.Web.Models.Instances;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Web.Controllers
{
    [AbpMvcAuthorize]
    public class InstancesController : eMMAControllerBase
    {
        private readonly IProfessorAppService _professorAppService;
        private readonly IInstanceAppService _instanceAppService;
        private readonly ISeminarAppService _seminarAppService;
        private readonly ILabAppService _lavAppService;



        public InstancesController(
            IInstanceAppService instanceAppService,
            ISeminarAppService seminarAppService,
            ILabAppService lavAppService,
            IProfessorAppService professorAppService
        )
        {
            _professorAppService = professorAppService;
            _instanceAppService = instanceAppService;
            _seminarAppService = seminarAppService;
            _lavAppService = lavAppService;
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

            return View("_AddInstanceModal", model);
        }

        [HttpPost]
        public async Task<string> AddInstance(string profId, string subjectId, string description, string name, UniClassType type)//CreateSubjectInstanceModel csim)
        {
            //var userId = User.Identity.GetUserId();
            //var prof = await _professorAppService.GetProfessorUserByAuthUserIdAsync(userId.Value);
            var dto = new InstanceDto()
            {
                Date = DateTime.Now,
                ProfId = new Guid(profId),
                SubjectId = new Guid(subjectId),
                Description = description,
                Name = name,
                UniClassType = type
            };

            var created = dto;
            switch (dto.UniClassType)
            {
                case UniClassType.Course:
                    created = await _instanceAppService.AddIUniClass(dto);
                    break;
                case UniClassType.Seminar:
                    created = await _seminarAppService.AddIUniClass(dto);
                    break;
                case UniClassType.Lab:
                    created = await _lavAppService.AddIUniClass(dto);
                    break;
            }


            return created.AttendenceCode; //$"AttendenceCode : \"created.AttendenceCode\"";//code; //
        }
    }
}