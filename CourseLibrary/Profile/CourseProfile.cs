using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace CourseLibrary.Profile
{
    public class CourseProfile : AutoMapper.Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseLibrary.API.Entities.Course, Models.CourseDto>();
        }
    }
}
