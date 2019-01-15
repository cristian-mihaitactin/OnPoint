using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using eMMA.Uni.Professor.Dto;
using eMMA.Uni.UniSubject.Dto;

namespace eMMA.Uni.Professor
{
    public interface IProfessorAppService : IAsyncCrudAppService<ProfessorDto, Guid, PagedResultRequestDto, ProfessorDto, ProfessorDto>
    {
        ProfessorDto UpdateSync(ProfessorDto input);
        Task<Entities.Professor> GetProfessorUserByAuthUserIdAsync(long id);
    }
}
