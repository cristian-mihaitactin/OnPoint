using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class StudentsViewModel
    {
        public StudentsViewModel(string matricol)
        {
            this.NrMatricol = matricol;
        }

        [Required]
        public string NrMatricol { get; private set; }
    }
}
