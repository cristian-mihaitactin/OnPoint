using eMMA.Uni.UniSubject.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMMA.Web.Models.UniSubjects
{
    public class UniSubjectListViewModel
    {
        public IReadOnlyList<UniSubjectDto> UniSubjects { get; set; }
    }
}
