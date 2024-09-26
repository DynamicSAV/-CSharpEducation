namespace EmployeeAccountingSystem;

public class PartTimeEmployee : Employee
{
  public override string Name { get; set; }

  public override decimal BaseSalary { get; }
  
  public int HoursWorked { get; set; }
  
  public override decimal CalculateSalary()
  {
    return BaseSalary * HoursWorked;
  }

  public PartTimeEmployee(string name, decimal hourlyRate)
  {
    this.Name = name;
    this.BaseSalary = hourlyRate;
  }
  
  public override string ToString()
  {
    return $"Имя: {Name}\n" +
           $"Часовая оплата: {BaseSalary}\n" +
           $"Кол-во отработанных часов: {HoursWorked}\n" +
           $"Зарплата: {CalculateSalary()}";
  }
  
}