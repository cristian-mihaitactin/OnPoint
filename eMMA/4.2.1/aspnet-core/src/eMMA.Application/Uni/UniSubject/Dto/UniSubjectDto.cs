using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using eMMA.Entities;

namespace eMMA.Uni.UniSubject.Dto
{
    [AutoMapFrom(typeof(eMMA.Entities.UniSubject))]
    public class UniSubjectDto : EntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<LaboratoryInstance> Labs { get; set; }
        public ICollection<SeminarInstance> Seminars { get; set; }
        public ICollection<CourseInstance> Courses { get; set; }

    }
}
