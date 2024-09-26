namespace EmployeeAccountingSystem;

public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
{
  private List<T> employees = new();
  
  public void Add(T employee)
  {
    employees.Add(employee);
  }

  public T Get(string name)
  {
    return employees.FirstOrDefault(e => e.Name == name);
  }

  public void Update(T employee)
  {
    var existingEmployee = Get(employee.Name);
    if (existingEmployee != null)
    {
      employees[employees.IndexOf(existingEmployee)] = employee;
    }
  }
}