using AutoMapper;
using CourseLibrary.API.Services;
using CourseLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace CourseLibrary.Controllers
{
    [ApiController]
    [Route("api/authors/{authorid}/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibRepo;
        private readonly IMapper _mapper;
        public CourseController(ICourseLibraryRepository courseLibRepo, IMapper mapper)
        {
            _courseLibRepo = courseLibRepo ?? throw new ArgumentNullException(nameof(courseLibRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetCoursesPerAuthors(Guid Authorid)
        {
          if (!_courseLibRepo.AuthorExists(Authorid))
            {
                return NotFound();
            }
            var courseFromRepo = _courseLibRepo.GetCourses(Authorid);
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(courseFromRepo));
        }
        [HttpGet("{courseId}")]
        public ActionResult<CourseDto>   GetcourseForAuthors(Guid AuthorId, Guid CourseId)
        {
            if (!_courseLibRepo.AuthorExists(AuthorId))
            {
                return NotFound();
            }
            var AurthorsForCourse = _courseLibRepo.GetCourse(AuthorId, CourseId);
            if(AurthorsForCourse == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CourseDto>(AurthorsForCourse));
        }
    }
}
