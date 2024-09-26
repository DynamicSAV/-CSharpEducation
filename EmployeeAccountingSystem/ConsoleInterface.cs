namespace EmployeeAccountingSystem;

/// <summary>
/// Предоставляет интерфейс командной строки для управления системой учета сотрудников.
/// </summary>
public class ConsoleInterface
{
  private EmployeeManager<FullTimeEmployee> fullTimeManager;
  private EmployeeManager<PartTimeEmployee> partTimeManager;
  
  /// <summary>
  /// Отображает главное меню и запрашивает у пользователя действие.
  /// </summary>
  public void MainMenu()
  {
    Console.Clear();
    Console.WriteLine(
      "1. Добавить полного сотрудника\n" +
      "2. Добавить частичного сотрудника\n" +
      "3. Получить информацию о сотруднике\n" +
      "4. Обновить данные сотрудника\n" +
      "5. Выйти\n" +
      "Выберите действие:"
    );
    GetAction();
  }

  /// <summary>
  /// Получает действие от пользователя и вызывает соответствующий метод.
  /// </summary>
  public void GetAction()
  {
    int selected = int.Parse(Console.ReadLine());
    switch (selected)
    {
      case 1:
        AddFullTimeEmployee();
        break;
      case 2:
        AddPartTimeEmployee();
        break;
      case 3:
        GetEmployeeInfo();
        break;
      case 4:
        UpdateEmployeeInfo();
        break;
      case 5:
        Environment.Exit(0);
        break;
      default:
        GetAction();
        break;
    }
  }

  /// <summary>
  /// Добавляет нового полного сотрудника.
  /// </summary>
  private void AddFullTimeEmployee()
  {
    Console.Clear();
    
    Console.WriteLine("Добавление полного сотрудника\n");
    Console.WriteLine("Введите имя нового сотрудника");
    string name = Console.ReadLine();
    Console.WriteLine("Введите зарплату сотрудника");
    decimal salary = decimal.Parse(Console.ReadLine());

    FullTimeEmployee employee = new FullTimeEmployee(name, salary);
    fullTimeManager.Add(employee);

    Console.WriteLine("Сотрудник добавлен. Нажмите любую клавишу для выхода в меню");
    Console.ReadKey();
    
    MainMenu();
  }
  
  /// <summary>
  /// Добавляет нового частично занятого сотрудника.
  /// </summary>
  private void AddPartTimeEmployee()
  {
    Console.Clear();
    
    Console.WriteLine("Добавление частичного сотрудника\n");
    Console.WriteLine("Введите имя нового сотрудника");
    string name = Console.ReadLine();
    Console.WriteLine("Введите часовую ставку сотрудника");
    decimal hourlyRate = decimal.Parse(Console.ReadLine());

    PartTimeEmployee employee = new PartTimeEmployee(name, hourlyRate);
    partTimeManager.Add(employee);

    Console.WriteLine("Сотрудник добавлен. Нажмите любую клавишу для выхода в меню");
    Console.ReadKey();
    
    MainMenu();
  }

  /// <summary>
  /// Получает информацию о сотруднике по его идентификатору.
  /// </summary>
  private void GetEmployeeInfo()
  {
    Console.Clear();
    
    Console.WriteLine("Получить иформацию о сотруднике\n");
    Console.WriteLine("Введите имя сотрудника: ");
    
    string name = Console.ReadLine();
    Employee fullTimeEmployee = fullTimeManager.Get(name);
    Employee partTimeEmployee = partTimeManager.Get(name);
    
    if (fullTimeEmployee != null)
    {
      Console.WriteLine(fullTimeEmployee.ToString());
    }
    else if (partTimeEmployee != null)
    {
      Console.WriteLine(partTimeEmployee.ToString());
    }
    else
    {
      Console.WriteLine("Сотрудник не найден.");
    }

    Console.WriteLine("Нажмите любую клавишу для выхода в меню");
    Console.ReadKey();
    MainMenu();
  }

  /// <summary>
  /// Обновляет информацию о существующем сотруднике.
  /// </summary>
  private void UpdateEmployeeInfo()
  {
    Console.Clear();
    Console.WriteLine("Обновить иформацию сотрудника\n");
    Console.WriteLine("Введите имя сотрудника: ");
    string name = Console.ReadLine();
    Employee fullTimeEmployee = fullTimeManager.Get(name);
    Employee partTimeEmployee = partTimeManager.Get(name);
    
    if (fullTimeEmployee != null)
    {
      Console.WriteLine(fullTimeEmployee.ToString());
      Console.WriteLine("Введите новую месячную ставку сотрудника / -1, чтобы пропустить");
      decimal salary = decimal.Parse(Console.ReadLine());
      if (salary != -1)
      {
        FullTimeEmployee updatedEmployee = new FullTimeEmployee(fullTimeEmployee.Name, salary);
        fullTimeManager.Update(updatedEmployee);
      }
    }
    else if (partTimeEmployee != null)
    {
      PartTimeEmployee updatedEmployee;
      Console.WriteLine(partTimeEmployee.ToString());
      Console.WriteLine("Введите новую часовую ставку сотрудника / -1, чтобы пропустить");
      decimal salary = decimal.Parse(Console.ReadLine());

      Console.WriteLine("Введите кол-во отработанных часов / -1, чтобы пропустить");
      int hoursWorked = int.Parse(Console.ReadLine());
      if (salary != -1)
      {
        updatedEmployee = new PartTimeEmployee(partTimeEmployee.Name, salary);
        if (hoursWorked != -1)
        {
          updatedEmployee.HoursWorked = hoursWorked;
        }
      }
      else
      {
        updatedEmployee = new PartTimeEmployee(partTimeEmployee.Name, partTimeEmployee.BaseSalary);
        if (hoursWorked != -1)
        {
          updatedEmployee.HoursWorked = hoursWorked;
        }
      }
      partTimeManager.Update(updatedEmployee);
    }
    else
    {
      Console.WriteLine("Сотрудник не найден.");
      Console.WriteLine("Нажмите любую клавишу для выхода в меню");
      Console.ReadKey();
      MainMenu();
    }
    
    Console.WriteLine("Нажмите любую клавишу для выхода в меню");
    Console.ReadKey();
    MainMenu();
  }

  public ConsoleInterface(EmployeeManager<FullTimeEmployee> fullTimeManager, EmployeeManager<PartTimeEmployee> partTimeManager)
  {
    this.fullTimeManager = fullTimeManager;
    this.partTimeManager = partTimeManager;
  }
}