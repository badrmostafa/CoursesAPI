using AutoMapper;
using CoursesAPI.Data;
using CoursesAPI.DTO.Course;
using CoursesAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IRepository<Course> repository;
        private readonly IMapper mapper;

        public CourseController(IRepository<Course> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        //api/course
        [HttpGet]
        public ActionResult GetCourses()
        {
            try
            {
                List<Course> courses = repository.GetAll();
                List<GetAllCourse> getAllCourses = mapper.Map<List<GetAllCourse>>(courses);
                return Ok(getAllCourses);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        //api/course/{id}
        [HttpGet("{id}")]
        public ActionResult GetCourse(int id)
        {
            try
            {
                Course course = repository.GetById(id);
                if (course == null)
                    return NotFound();
                GetCourse getCourse = mapper.Map<GetCourse>(course);
                return Ok(getCourse);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        //api/course
        [HttpPost]
        public ActionResult InsertCourse(AddCourse addCourse)
        {
            try
            {
                Course course = mapper.Map<Course>(addCourse);
                repository.Add(course);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //api/course/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCourse(int id,EditCourse editCourse)
        {
            try
            {
                Course course = repository.GetById(id);
                if (course == null)
                    return NotFound();
                course = mapper.Map(editCourse,course);
                repository.Update(course);
                return Ok();
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //api/course/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            try
            {
                repository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
