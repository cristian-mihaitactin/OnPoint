using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using eMMA.Uni.Professor.Dto;

namespace eMMA.Uni.Professor
{
    public interface IProfessorAppService : IAsyncCrudAppService<ProfessorDto, Guid, PagedResultRequestDto, ProfessorDto, ProfessorDto>
    {
        ProfessorDto UpdateSync(ProfessorDto input);
        Task<Entities.Professor> GetProfessorUserByAuthUserIdAsync(long id);
    }
}
