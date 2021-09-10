using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseLibrary.API.Entities;
using CourseLibrary.Helpers;


namespace CourseLibrary.Profile
{
    public class AuthorsProfile : AutoMapper.Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Author, Models.AuthorsDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName}{src.LastName}"))
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));
        }
    }
}
