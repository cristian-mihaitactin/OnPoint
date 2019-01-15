using System;
using System.Collections.Generic;
using System.Text;

namespace eMMA.Entities
{
    public class Professor : User
    {
        public ICollection<ProfessorUniSubjects> ObjectList { get; set; }

        public Professor()
        {
            ObjectList = new List<ProfessorUniSubjects>();
        }

        public void ApproveAttendance(Student student)
        {
            //TO BE IMPLEMENTED
        }

        public void DisapproveAttendance(Student student)
        {
            //TO BE IMPLEMENTED
        }

        public void GradeHomework()
        {
            //TO BE IMPLEMENTED
        }

        public void CreateCourse()
        {
            //TO BE IMPLEMENTED
        }

        public void CreateLaboratory()
        {
            //TO BE IMPLEMENTED
        }

        public void CreateSeminar()
        {
            //TO BE IMPLEMENTED
        }
    }
}
