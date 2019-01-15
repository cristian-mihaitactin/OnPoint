using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMMA.Entities;
using eMMA.Uni.UniSubject.Dto;

namespace eMMA.Web.Models.UniSubjects
{
    public class UniSubjectViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public string Description { get; set; }

        public ICollection<LaboratoryInstance> Labs { get; set; }
        public ICollection<SeminarInstance> Seminars { get; set; }
        public ICollection<CourseInstance> Courses { get; set; }

        public UniSubjectViewModel(UniSubjectDto dto)
        {
            Id = dto.Id;
            Title = dto.Title;
            Credits = dto.Credits;
            Description = dto.Description;
            Labs = new List<LaboratoryInstance>(dto.Labs);
            Seminars = new List<SeminarInstance>(dto.Seminars);
            Courses = new List<CourseInstance>(dto.Courses);
        }

        public UniSubjectDto GetDto()
        {
            return new UniSubjectDto()
            {
                Id = Id,
                Description = Description,
                Seminars = Seminars,
                Labs = Labs,
                Credits = Credits,
                Title = Title,
                Courses = Courses
            };
        }
    }
    public class UniSubjectEditViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public string Description { get; set; }

        public UniSubjectEditViewModel()
        {

        }

        public UniSubjectEditViewModel(UniSubjectDto dto)
        {
            Id = dto.Id;
            Title = dto.Title;
            Credits = dto.Credits;
            Description = dto.Description;
        }

        public UniSubjectDto GetDto()
        {
            return new UniSubjectDto()
            {
                Id = Id,
                Description = Description,
                Credits = Credits,
                Title = Title
            };
        }
    }
}
