using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using eMMA.Entities;

namespace eMMA.Uni.Professor.Dto
{
    [AutoMapFrom(typeof(eMMA.Entities.Professor))]
    public class ProfessorDto : EntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long UserId { get; set; }

        public ICollection<ProfessorUniSubjects> ObjectList { get; set; }

    }
}
