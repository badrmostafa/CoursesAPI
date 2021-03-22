using AutoMapper;
using CoursesAPI.DTO.Category;
using CoursesAPI.DTO.Course;
using CoursesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesAPI.Mapper
{
    public class AutoMap : Profile
    {
        public AutoMap()
        {
            CreateMap<Category, GetAllCategory>();
            CreateMap<Category, GetCategory>();
            CreateMap<AddCategory, Category>();
            CreateMap<EditCategory, Category>();

            CreateMap<Course, GetAllCourse>();
            CreateMap<Course, GetCourse>();
            CreateMap<AddCourse, Course>();
            CreateMap<EditCourse, Course>();

        }
    }
}
