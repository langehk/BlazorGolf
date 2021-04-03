using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Dto;

namespace WebApp
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Player, PlayerDto>()
                .ReverseMap();

            CreateMap<Score, ScoreDto>()
                .ReverseMap();

            CreateMap<Course, CourseDto>()
                .ReverseMap();
        }

    }
}
