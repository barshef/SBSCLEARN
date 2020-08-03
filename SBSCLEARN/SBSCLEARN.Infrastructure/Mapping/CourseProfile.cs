using AutoMapper;
using SBSCLEARN.Domain.Entities;
using SBSCLEARN.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSCLEARN.Infrastructure.Mapping
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseModel, Course>()
                .ForMember(dest => dest.Id,
                        opt => opt.MapFrom(src => src.CourseId))
                .ReverseMap();
        }
    }
}
