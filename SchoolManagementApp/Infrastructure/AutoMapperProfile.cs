using AutoMapper;
using DomainModel.Models;
using DomainModel.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementApp.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<LoginDto, Login>();
            CreateMap<Login, LoginDto>();

        }
        public static void Run()
        {
            Mapper.Initialize(a =>
            {
                a.AddProfile<AutoMapperProfile>();
            });
        }
    }
}