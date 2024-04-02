using WebApi.Models;
using WebApi.Responses;

namespace WebApi.Services;

public interface IStudentService
{
    Response<List<Student>> GetStudents();
    Response<Student> GetStudentById(int id);
    Response<string> AddStudent(Student student);
    Response<string> UpdateStudent(Student student);
    Response<bool> DeleteStudent(int id);
}