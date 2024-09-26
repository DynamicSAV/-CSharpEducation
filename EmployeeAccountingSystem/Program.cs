namespace EmployeeAccountingSystem;

class Program
{
  static void Main(string[] args)
  {
    EmployeeManager<FullTimeEmployee> fullTimeEmployeeManager = new EmployeeManager<FullTimeEmployee>();
    EmployeeManager<PartTimeEmployee> partTimeEmployeeManager = new EmployeeManager<PartTimeEmployee>();

    ConsoleInterface consoleInterface = new ConsoleInterface(fullTimeEmployeeManager, partTimeEmployeeManager);
    
    consoleInterface.MainMenu();
  }
}