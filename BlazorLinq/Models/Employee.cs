using System.ComponentModel.DataAnnotations;

public class Employee
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "Formato de mail inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "La edad es obligatoria.")]
    [Range(1, 100, ErrorMessage = "La edad debe ser entre 1 y 100.")]
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