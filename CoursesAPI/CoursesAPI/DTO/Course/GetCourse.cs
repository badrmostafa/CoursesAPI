using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesAPI.DTO.Course
{
    public class GetCourse
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public decimal CoursePrice { get; set; }
        public int CategoryId { get; set; }
    }
}
