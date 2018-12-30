using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication.ViewModels
{
    public class UniSubjectsViewModel
    {
        public string Title { get; set; }
        public List<UniSubject> UniSubjects { get; set; }
    }
}
