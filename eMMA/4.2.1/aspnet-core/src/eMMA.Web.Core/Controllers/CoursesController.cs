using System;
using System.Linq;
using eMMA.EntityFrameworkCore.Repositories;
using eMMA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eMMA.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CoursesController : eMMAControllerBase
    {
        private readonly eMMARepositoryBase<CourseInstance, Guid> _courseRepository;

        public CoursesController(eMMARepositoryBase<CourseInstance, Guid> courseRepository)
        {
            _courseRepository = courseRepository;
        }
        
        [HttpGet]
        public CourseInstance GetCourse(Guid id)
        {
            var course = _courseRepository.FindBy(m => m.Id == id).FirstOrDefault();
            return course;
        }

        [HttpPost]
        public void PostCourse(CourseInstance course)
        {
            _courseRepository.Edit(course);
            _courseRepository.Save();
        }

        [HttpPut]
        public void PutCourse(CourseInstance course)
        {
            _courseRepository.Add(course);
            _courseRepository.Save();
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            var course = _courseRepository.FindBy(m => m.Id == id).FirstOrDefault();
            _courseRepository.Delete(course);
            _courseRepository.Save();
        }
    }
}