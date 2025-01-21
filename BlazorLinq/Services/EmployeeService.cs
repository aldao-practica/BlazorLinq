using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BlazorLinq.Components.Pages;

public class EmployeeService : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private List<Employee> _employees;

    public List<Employee> Employees
    {
        get => _employees;
        private set
        {
            _employees = value;
            NotifyPropertyChanged(nameof(Employees));
        }
    }

    // Constructor para inicializar la lista con datos predeterminados
    public  EmployeeService()
    {
        Employees = new List<Employee>
        {
            new Employee(1, "Juan", "Pérez", "juan.perez@example.com", 25),
            new Employee(2, "María", "González", "maria.gonzalez@example.com", 17),
            new Employee(3, "Lucía", "Fernández", "lucia.fernandez@example.com", 30),
            new Employee(4, "Carlos", "Rodríguez", "carlos.rodriguez@example.com", 20),
            new Employee(5, "Sofía", "Martínez", "sofia.martinez@example.com", 16)
        };
    }

    // Métodos para gestionar la lista
    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
        NotifyPropertyChanged(nameof(Employees));
    }

    public void RemoveEmployee(int id)
    {
        var employee = Employees.FirstOrDefault(e => e.Id == id);
        if (employee != null)
        {
            Employees.Remove(employee);
            NotifyPropertyChanged(nameof(Employees));
        }
    }

    public Employee GetEmployeeById(int id)
    {
        return Employees.FirstOrDefault(e => e.Id == id);
    }

    public List<Employee> GetAllEmployees()
    {
        return Employees;
    }

    public void UpdateEmployee(Employee updatedEmployee)
    {
        var employee = Employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
        if (employee != null)
        {
            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.Email = updatedEmployee.Email;
            employee.Age = updatedEmployee.Age;
            NotifyPropertyChanged(nameof(Employees));
        }
    }

    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
