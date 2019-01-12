using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using eMMA.Uni.UniSubject.Dto;
using eMMA.Entities;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using eMMA.EntityFrameworkCore.Repositories;

namespace eMMA.Uni.UniSubject
{
    public class UniSubjectAppService : AsyncCrudAppService<Entities.UniSubject, UniSubjectDto, Guid, PagedResultRequestDto, UniSubjectDto, UniSubjectDto>, IUniSubjectAppService
    {
        public UniSubjectAppService(eMMARepositoryBase<Entities.UniSubject, Guid> repository)
                : base(repository)
        {
            
        }
        public async Task<ListResultDto<UniSubjectDto>> GetAllUniSubjects()
        {
            var task = Repository.GetAllListAsync();
            var allSubjects = await task;

            var listResultDto = new List<UniSubjectDto>();

            foreach (var subject in allSubjects)
            {
                var dtoSubj = ObjectMapper.Map<UniSubjectDto>(subject);
                listResultDto.Add(dtoSubj);
            }

            return  new ListResultDto<UniSubjectDto>(listResultDto);

        }
    }
}
