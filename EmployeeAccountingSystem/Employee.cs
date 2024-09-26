namespace EmployeeAccountingSystem;

public abstract class Employee
{
  public abstract string Name { get; set; }
  public abstract decimal BaseSalary { get; }
  public abstract decimal CalculateSalary();
}