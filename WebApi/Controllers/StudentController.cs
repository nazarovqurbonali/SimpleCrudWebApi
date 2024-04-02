using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Responses;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/Students/")]
public class StudentController(IStudentService studentService):ControllerBase
{
    private readonly IStudentService _studentService = studentService;

    [HttpGet]
    public Response<List<Student>> GetStudents()
    {
        return _studentService.GetStudents();
    }
    
    [HttpGet("{studentId:int}")]
    public Response<Student> GetStudentById(int studentId)
    {
        return _studentService.GetStudentById(studentId);
    }
    
    [HttpPost]
    public Response<string> Add(Student student)
    {
        return _studentService.AddStudent(student);
    }
    [HttpPut]
    public Response<string> Update(Student student)
    {
        return _studentService.UpdateStudent(student);
    }
    [HttpDelete("{studentId:int}")]
    public Response<bool> Delete(int studentId)
    {
        return _studentService.DeleteStudent(studentId);
    }
}