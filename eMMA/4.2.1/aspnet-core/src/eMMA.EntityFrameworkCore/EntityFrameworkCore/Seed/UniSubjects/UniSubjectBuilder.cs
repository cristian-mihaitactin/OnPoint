using System;
using System.Linq;
using eMMA.Entities;

namespace eMMA.EntityFrameworkCore.Seed.UniSubjects
{
    public class UniSubjectBuilder
    {
        private readonly eMMADbContext _context;
        //private readonly int _tenantId;

        public UniSubjectBuilder(eMMADbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUniSubject();
        }

        private void CreateUniSubject()
        {

            //.NET object
            var subjectNET = new UniSubject()
            {
                Id = new Guid(),
                Title = "Introducere in .NET",
                Credits = 4
            };
            var subject = _context.UniSubjects.FirstOrDefault(r => r.Title == subjectNET.Title);
            if(subject == null)
            {
                _context.UniSubjects.Add(subjectNET);
            }

            //ML object
            var subjectML = new UniSubject()
            {
                Id = new Guid(),
                Title = "Invatare Automata",
                Credits = 6,
                Description = "Invata automat."
            };
            var subject2 = _context.UniSubjects.FirstOrDefault(r => r.Title == subjectML.Title);
            if (subject2 == null)
            {
                _context.UniSubjects.Add(subjectML);
            }

            //Python object
            var subjectPython = new UniSubject()
            {
                Id = new Guid(),
                Title = "Python",
                Credits = 4,
                Description = "Cum sa pescuiesti pesti"
            };
            var subject3 = _context.UniSubjects.FirstOrDefault(r => r.Title == subjectPython.Title);
            if (subject3 == null)
            {
                _context.UniSubjects.Add(subjectPython);
            }

            //Inteligenta artificala object
            var subjectIA = new UniSubject()
            {
                Id = new Guid(),
                Title = "Inteligenta artificiala",
                Credits = 6,
                Description = "Invata si mai automat decat automat"
            
            };
            var subject4 = _context.UniSubjects.FirstOrDefault(r => r.Title == subjectIA.Title);
            if (subject4 == null)
            {
                _context.UniSubjects.Add(subjectIA);
            }
            _context.SaveChanges();
            
            }

      }
}

