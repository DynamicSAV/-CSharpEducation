namespace EmployeeAccountingSystem;

public class FullTimeEmployee : Employee
{
  public override string Name { get; set; }
  public override decimal BaseSalary { get; }

  public override decimal CalculateSalary()
  {
    return BaseSalary ;
  }

  public FullTimeEmployee(string name, decimal baseSalary)
  {
    this.Name = name;
    this.BaseSalary = baseSalary;
  }

  public override string ToString()
  {
    return $"Имя: {Name}\n" +
           $"Оклад: {BaseSalary}\n" +
           $"Зарплата: {CalculateSalary()}";
  }
}