using System.Collections.Generic;
using eMMA.Uni.UniSubject.Dto;

namespace eMMA.Web.Models.UniSubjects
{
    public class MySubjectViewModel
    {
        public List<UniSubjectDto> Subjects { get; set; }

        public MySubjectViewModel()
        {
            Subjects = new List<UniSubjectDto>();
        }

        public MySubjectViewModel(List<UniSubjectDto> subjects)
        {
            Subjects = subjects;
        }
    }
}
