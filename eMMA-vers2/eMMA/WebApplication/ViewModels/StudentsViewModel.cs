using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication.ViewModels
{
    public class StudentsViewModel
    {
        public string Title { get; set; }
        public List<Student> Students { get; set; }
    }
}
