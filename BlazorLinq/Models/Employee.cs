public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public Employee(int id, string firstName, string lastName, string email, int age)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Age = age;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {FirstName} {LastName}, Email: {Email}, Age: {Age}";
    }
}