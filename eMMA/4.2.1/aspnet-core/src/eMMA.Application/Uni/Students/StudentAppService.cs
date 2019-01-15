using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using eMMA.Entities;
using eMMA.Uni.Students.Dto;

namespace eMMA.Uni.Students
{
    public class StudentAppService : AsyncCrudAppService<Entities.Student, StudentDto, Guid, PagedResultRequestDto, StudentDto, StudentDto>, IStudentAppService
    {
        public StudentAppService(IRepository<Student, Guid> repository) : base(repository)
        {
        }
        public async Task<Entities.Student> GetStudentUserByAuthUserIdAsync(long id)
        {
            var studList = await Repository.GetAllListAsync(p => p.UserId == id);

            var prof = studList.FirstOrDefault();
            return prof;
        }
    }
}
