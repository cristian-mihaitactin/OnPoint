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
using Abp.Domain.Entities;

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

        public Task<Entities.UniSubject> GetSubjectByIdAsync(Guid id)
        {
            return GetEntityByIdAsync(id);
        }


        protected override async Task<Entities.UniSubject> GetEntityByIdAsync(Guid id)
        {
            var subject = await Repository.GetAsync(id);

            if (subject == null)
            {
                throw new EntityNotFoundException(typeof(Entities.UniSubject), id);
            }

            return subject;
        }
    }
}
