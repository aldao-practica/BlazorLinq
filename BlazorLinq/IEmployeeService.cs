namespace BlazorLinq
{
    public interface IEmployeeService
    {
        string Uid { get; set; }
        List<Employee> GetAllEmployees();

        Employee GetEmployeeById(int id);

        void AddEmployee(Employee employee);

        void RemoveEmployee(int id);

        void UpdateEmployee(Employee employee);
    }
}
