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
    public class BookController : Controller
    {
        private static readonly List<Book> books = new List<Book>
        {
            new Book()
            {
                Id=1,
                Name="Math",
                CourseId=1,
               
            },
             new Book()
            {
                Id=2,
                Name="IT",
               CourseId=2,

            },
               new Book()
            {
                Id=3,
                Name="English",
                CourseId=3,


            }

        };
        // Get Method 
        [HttpGet]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public List<Book> GetAllBooks() // return list of courses  when read book return 200 else return other thing 
        {
            return books;
        }

        [Route("{Id}")] // if the function take parameter and the type is get we send the parameter in Route 
        [HttpGet]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public Book GetBookById(int Id)
        {
            return books.FirstOrDefault(C => C.Id == Id);
        }

        [Route("CourseId/{Id}")]
        [HttpGet]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public Book GetByCourseId(int Id)
        {
            return books.FirstOrDefault(C => C.CourseId ==Id);
        }
        

        [HttpPost] // for create 
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Book Create([FromBody] Book book) 
        {
            return new Book(); 
        }

        [HttpPut] // for update 
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public Book Update([FromBody] Book book)
        {
            return new Book();
        }


        [HttpDelete("{Id}")]
        public bool Delete(int Id)
        {
            return true;
        }


    }
}
