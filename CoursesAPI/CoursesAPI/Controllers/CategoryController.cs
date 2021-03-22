using AutoMapper;
using CoursesAPI.Data;
using CoursesAPI.DTO.Category;
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
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public CategoryController(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        //api/category
        [HttpGet]
        public ActionResult GetCategories()
        {
            try
            {
                List<Category> categories = repository.GetAll();
                List<GetAllCategory> getAllCategories = mapper.Map<List<GetAllCategory>>(categories);
                return Ok(getAllCategories);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        //api/category/{id}
        [HttpGet("{id}")]
        public ActionResult GetCategory(int id)
        {
            try
            {
                Category category = repository.GetById(id);
                if (category == null)
                    return NotFound();

                GetCategory getCategory = mapper.Map<GetCategory>(category);
                return Ok(category);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        //api/category
        [HttpPost]
        public ActionResult InsertCategory(AddCategory addCategory)
        {
            try
            {
                if (addCategory == null)
                    return BadRequest();
                Category category = mapper.Map<Category>(addCategory);
                repository.Add(category);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //api/category/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id,EditCategory editCategory)
        {
            try
            {
                Category category = repository.GetById(id);
                if (category == null)
                    return NotFound();
                Category c = mapper.Map(editCategory,category);
                repository.Update(c);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //api/category/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
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
