using System.Net;
using Dapper;
using WebApi.DataContext;
using WebApi.Models;
using WebApi.Responses;

namespace WebApi.Services;

public class StudentService : IStudentService
{
    private readonly DapperContext _context;

    public StudentService(DapperContext context)
    {
        _context = context;
    }

    public Response<List<Student>> GetStudents()
    {
        try
        {
            var sql = @"SELECT * FROM students";
            var students = _context.Connection().Query<Student>(sql).ToList();
            return new Response<List<Student>>(students);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Response<List<Student>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public Response<Student> GetStudentById(int id)
    {
        try
        {
            var sql = @$"SELECT * FROM students where id={@id}";
            var result = _context.Connection().QueryFirstOrDefault<Student>(sql);
             if(result!=null) return new Response<Student>(result);
             return new Response<Student>(HttpStatusCode.BadRequest, "Student not found");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Response<Student>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public Response<string> AddStudent(Student student)
    {
        try
        {
            var sql = @$"insert into students(firstname,lastname,age,address,email,phone)
                      values ('{student.FirstName}', '{student.LastName}', '{student.Age}', 
                       '{student.Address}', '{student.Email}','{student.Phone}')";
            var result = _context.Connection().Execute(sql);
            if (result > 0) return new Response<string>("Successfully created student");
            return new Response<string>(HttpStatusCode.BadRequest, "Could not create student");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public Response<string> UpdateStudent(Student student)
    {
        try
        {
            var sql = @$"Update Students SET firstname='{student.FirstName}',
                lastname='{student.LastName}',age={student.Age},phone='{student.Phone}',
                address='{student.Address}',email='{student.Email}'
                 where id={student.Id}";

            var result = _context.Connection().Execute(sql);
            if (result > 0) return new Response<string>("Successfully updated student");
            return new Response<string>(HttpStatusCode.BadRequest, "Could not update student");
        }
        catch (Exception e)
        { Console.WriteLine(e.Message);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public Response<bool> DeleteStudent(int id)
    {
        try
        {
            var sql = @$"Delete FROM students where id={@id}";
            var result = _context.Connection().Execute(sql);
            if (result > 0) return new Response<bool>(true);
            return new Response<bool>(HttpStatusCode.BadRequest, "Not found student",false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}