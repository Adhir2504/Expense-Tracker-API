using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.DTOs;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Age = 20, Course = "Math"},
            new Student { Id = 2, Name = "Bob", Age = 20, Course = "Science"},
        };

        [HttpGet]
        public IActionResult GetAllStudents() 
        {
            // Convert models to DTOs (manual mapping)
            var result = _students.Select(s => new StudentDTO
            {
                Name = s.Name,
                Age = s.Age,
                Course = s.Course
            });
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddStudent(StudentDTO studentDto) 
        {
            //manual mapping from dto to model
            var newStudent = new Student
            {
                Id = _students.Count + 1,
                Name = studentDto.Name,
                Age = studentDto.Age,
                Course = studentDto.Course
            };
            _students.Add(newStudent);

            return CreatedAtAction(nameof(GetAllStudents),new { id = newStudent.Id }, studentDto);
        }
    }
}
