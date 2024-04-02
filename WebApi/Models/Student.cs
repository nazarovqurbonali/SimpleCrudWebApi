namespace WebApi.Models;

public class Student
{
    public int Id { get; set; }
    public required  string FirstName { get; set; }
    public required string LastName { get; set; }
    public int  Age { get; set; }
    public required string Phone { get; set; }
    public required string Address { get; set; }
    public required string Email { get; set; }
}