using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using eMMA.Uni.Students.Dto;

namespace eMMA.Uni.Students
{
    public interface IStudentAppService : IAsyncCrudAppService<StudentDto, Guid, PagedResultRequestDto, StudentDto, StudentDto>
    {
        Task<Entities.Student> GetStudentUserByAuthUserIdAsync(long id);
    }
}
