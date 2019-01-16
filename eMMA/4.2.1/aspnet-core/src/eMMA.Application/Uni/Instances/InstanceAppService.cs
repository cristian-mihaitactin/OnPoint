using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using eMMA.Entities;
using eMMA.Uni.Instances.Dto;

namespace eMMA.Uni.Instances
{
    public class InstanceAppService : AsyncCrudAppService<Entities.CourseInstance, InstanceDto, Guid, PagedResultRequestDto, InstanceDto, InstanceDto>, IInstanceAppService
    {
        private readonly IRepository<CourseInstance, Guid> _repositoryCourses;

        //This needs to be split up in 3 different appServices
        public InstanceAppService(IRepository<CourseInstance, Guid> repositoryCourses
            ) : base(repositoryCourses)
        {
        }

        public async Task<InstanceDto> AddIUniClass(InstanceDto instanceDto)
        {
            string attendenSubstring = Guid.NewGuid().ToString().Trim('-').Substring(0, 7);

            switch (instanceDto.UniClassType)
            {
                case UniClassType.Course:
                    CourseInstance course = new CourseInstance()
                    {
                        Description =  instanceDto.Description,
                        AttendenceCode = attendenSubstring,
                        Date = instanceDto.Date,
                        Name = instanceDto.Name,
                        ProfId = instanceDto.ProfId,
                        SubjectId = instanceDto.SubjectId,
                        UniClassType = UniClassType.Course
                    };
                    course = await Repository.InsertAsync(course);
                    return ObjectMapper.Map<InstanceDto>((IUniClass)course);
                    break;
                
            }

            return null;
        }
    }
}
