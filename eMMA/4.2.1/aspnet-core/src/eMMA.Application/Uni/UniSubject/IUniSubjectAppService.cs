using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using eMMA.Uni.UniSubject.Dto;

namespace eMMA.Uni.UniSubject
{
    public interface IUniSubjectAppService : IAsyncCrudAppService<UniSubjectDto, Guid, PagedResultRequestDto, UniSubjectDto, UniSubjectDto>
    {
        Task<ListResultDto<UniSubjectDto>> GetAllUniSubjects();
        Task<Entities.UniSubject> GetSubjectByIdAsync(Guid id);
    }
}
