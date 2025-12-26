using StudentManagementAPI.Models;

namespace StudentManagementAPI.Interfaces
{
    public interface IStudentRepository
    {
        public interface IstudentRepository 
        {
            IEnumerable<Student> GetAll();
            Student? GetById(int id);
            void Add(Student student);
        }
    }
}
