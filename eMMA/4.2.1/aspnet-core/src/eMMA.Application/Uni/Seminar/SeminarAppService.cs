using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using eMMA.Entities;
using eMMA.Uni.Instances.Dto;

namespace eMMA.Uni.Instances
{
    public class SeminarAppService : AsyncCrudAppService<Entities.SeminarInstance, InstanceDto, Guid, PagedResultRequestDto, InstanceDto, InstanceDto>, ISeminarAppService
    {
        private readonly IRepository<SeminarInstance, Guid> _repositorySeminars;

        //This needs to be split up in 3 different appServices
        public SeminarAppService(
            IRepository<SeminarInstance, Guid> repositorySeminars
            ) : base(repositorySeminars)
        {
            _repositorySeminars = repositorySeminars;
        }

        public async Task<InstanceDto> AddIUniClass(InstanceDto instanceDto)
        {
            string attendenSubstring = Guid.NewGuid().ToString().Trim('-').Substring(0, 7);

            switch (instanceDto.UniClassType)
            {
                
                case UniClassType.Seminar:
                    SeminarInstance seminar = new SeminarInstance()
                {
                    Description = instanceDto.Description,
                    AttendenceCode = attendenSubstring,
                    Date = instanceDto.Date,
                    Name = instanceDto.Name,
                    ProfId = instanceDto.ProfId,
                    SubjectId = instanceDto.SubjectId,
                    UniClassType = UniClassType.Course
                };
                    seminar = await _repositorySeminars.InsertAsync(seminar);
                    return ObjectMapper.Map<InstanceDto>((IUniClass)seminar);
                    
                    break;
            }

            return null;
        }
    }
}
