using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using eMMA.Entities;

namespace eMMA.Uni.Instances.Dto
{
    [AutoMapFrom(typeof(eMMA.Entities.IUniClass))]
    public class InstanceDto : EntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AttendenceCode { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public ICollection<Student> AttendingList { get; set; }
        public string Description { get; set; }
        public ICollection<File> FileList { get; set; }
        public ICollection<Question> QuestionList { get; set; }
        public Guid SubjectId { get; set; }
        public Guid ProfId { get; set; }
        public UniClassType UniClassType { get; set; }
    }
}
