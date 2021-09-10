using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseLibrary.API.Services;
using CourseLibrary.Models;
using CourseLibrary.Helpers;
using AutoMapper;
using CourseLibrary.ResourcePrameters;

namespace CourseLibrary.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;
        public AuthorsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorsDto>> GetAuthors([FromQuery]AuthorsResourceParameters authorsparam)
        {
            //throw new Exception("Test Exception");
           var authorsFromRepo =  _courseLibraryRepository.GetAuthors(authorsparam);

            return Ok(_mapper.Map<IEnumerable<AuthorsDto>>(authorsFromRepo));
            
        }
        [HttpGet("{authorId:Guid}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var singleAuthorfromRepo = _courseLibraryRepository.GetAuthor(authorId);
            if(singleAuthorfromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AuthorsDto>(singleAuthorfromRepo));
        }
    }
}
