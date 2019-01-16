using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using eMMA.Entities;
using eMMA.Uni.Instances.Dto;

namespace eMMA.Uni.Instances
{
    public class LabAppService : AsyncCrudAppService<Entities.LaboratoryInstance, InstanceDto, Guid, PagedResultRequestDto, InstanceDto, InstanceDto>, ILabAppService
    {
        private readonly IRepository<LaboratoryInstance, Guid> _repositoryLab;

        //This needs to be split up in 3 different appServices
        public LabAppService(IRepository<LaboratoryInstance, Guid> repositoryLab
            ) : base(repositoryLab)
        {
            _repositoryLab= repositoryLab;
        }

        public async Task<InstanceDto> AddIUniClass(InstanceDto instanceDto)
        {
            string attendenSubstring = Guid.NewGuid().ToString().Trim('-').Substring(0, 7);

            switch (instanceDto.UniClassType)
            {
                case UniClassType.Lab:
                    LaboratoryInstance lab = new LaboratoryInstance()
                {
                    Description = instanceDto.Description,
                    AttendenceCode = attendenSubstring,
                    Date = instanceDto.Date,
                    Name = instanceDto.Name,
                    ProfId = instanceDto.ProfId,
                    SubjectId = instanceDto.SubjectId,
                    UniClassType = UniClassType.Course
                };

                    lab = await Repository.InsertAsync(lab);
                    return ObjectMapper.Map<InstanceDto>((IUniClass)lab);

                    break;
            }

            return null;
        }
    }
}
