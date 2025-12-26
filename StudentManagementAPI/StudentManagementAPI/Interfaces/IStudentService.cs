using StudentManagementAPI.DTOs;
using StudentManagementAPI.Models;
using System.Collections.Generic;

namespace StudentManagementAPI.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> GetAllStudents();
        StudentDTO? GetStudentById(int id);
        void AddStudent(StudentDTO studentDto);
    }
}
