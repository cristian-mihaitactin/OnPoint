using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
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
            var subject = _context.UniSubjects.FirstOrDefault(r => r.Id == subjectNET.Id);
            if(subject == null)
            {
                _context.UniSubjects.Add(subjectNET);
            }

            //ML object
            var subjectML = new UniSubject()
            {
                Id = new Guid(),
                Title = "Invatare Automata",
                Credits = 6
            };
            var subject2 = _context.UniSubjects.FirstOrDefault(r => r.Id == subjectML.Id);
            if (subject2 == null)
            {
                _context.UniSubjects.Add(subjectML);
            }

            //Python object
            var subjectPython = new UniSubject()
            {
                Id = new Guid(),
                Title = "Python",
                Credits = 4
            };
            var subject3 = _context.UniSubjects.FirstOrDefault(r => r.Id == subjectPython.Id);
            if (subject3 == null)
            {
                _context.UniSubjects.Add(subjectPython);
            }

            //Inteligenta artificala object
            var subjectIA = new UniSubject()
            {
                Id = new Guid(),
                Title = "Inteligenta artificiala",
                Credits = 6
            
            };
            var subject4 = _context.UniSubjects.FirstOrDefault(r => r.Id == subjectIA.Id);
            if (subject4 == null)
            {
                _context.UniSubjects.Add(subjectIA);
            }
            _context.SaveChanges();
            
            }

      }
}

