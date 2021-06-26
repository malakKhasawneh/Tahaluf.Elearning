using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tahaluf.Elearning.API.Data;

namespace Tahaluf.Elearning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private static readonly List<Course> courses = new List<Course>
        {
            new Course()
            {
                Id=1,
                Name="Math101",
                CreateDate= new DateTime(),
                Category="Maths"

            },
             new Course()
            {
                Id=2,
                Name="IT101",
                CreateDate= new DateTime(),
                Category="IT"

            },
               new Course()
            {
                Id=3,
                Name="English101",
                CreateDate= new DateTime(),
                Category="Languages"

            }

        };

        // Get Method 
        [HttpGet]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        public List<Course> GetAllCourses() // return list of courses  when read course return 200 else return other thing 
        {
            return courses;
        }
        [Route("{Id}")] // if the function take parameter and the type is get we send the parameter in Route 
        [HttpGet]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        public Course GetCourseById(int Id)
        {
            return courses.FirstOrDefault(C => C.Id == Id);
        }
       
        [Route("CourseName/{CourseName}")] // وحده انا بعطيه ياه وحده هو باخذها من عنده
        [HttpGet]
        [ProducesResponseType(typeof(List<Course>), StatusCodes.Status200OK)] // no errors 
        [ProducesResponseType(StatusCodes.Status404NotFound)] // no error
        public List<Course> GetWithOptionaValue(string CourseName,[FromQuery] string Category)
        {
            // from query mean the system get the value انا ما ببعتها اله  هو بقراه لحاله وبجيبه لحاله 
           
            // return the info of course 
            if (Category==null)
            {
                return courses.Where(c => c.Name == CourseName).ToList();
            }
            else
            {
                return courses.Where(c => c.Name == CourseName && c.Category==Category).ToList();
            }
        }

        // Post Method 

        [HttpPost] // for create 
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Course Create([FromBody] Course course) // read the values of parameter from body 
        {
            return new Course(); // the values that read from body send it to the course 
        }


        // Put Method 
        [HttpPut] // for update 
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public Course Update([FromBody] Course course)  
        {
            return new Course(); 
        }

        // Delete Method 

        [HttpDelete("{Id}")]
        public bool Delete(int Id)
        {
            return true;
        }



    }
}
