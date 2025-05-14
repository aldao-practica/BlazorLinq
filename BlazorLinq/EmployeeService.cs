namespace BlazorLinq
{
    public class EmployeeService : IEmployeeService
    {
        public string Uid { get; set; }
        private List<Employee> _employees;

        public EmployeeService()
        {
            Uid = Guid.NewGuid().ToString();
            _employees = new List<Employee>
            {
                new Employee(1, "Juan Pérez", "juan.perez@example.com", 11),
                new Employee(2, "María González", "maria.gonzalez@example.com", 17),
                new Employee(3, "Lucía Fernández", "lucia.fernandez@example.com", 30),
                new Employee(4, "Carlos Rodríguez", "carlos.rodriguez@example.com", 20),
                new Employee(5, "Sofía Martínez", "sofia.martinez@example.com", 16)
            };
        }

        public Employee GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(c => c.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public void RemoveEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public void UpdateEmployee(Employee updatedEmployee)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (employee != null)
            {
                employee.FullName = updatedEmployee.FullName;
                employee.Email = updatedEmployee.Email;
                employee.Age = updatedEmployee.Age;
            }
        }
    }
}
