namespace Exceptions;

public class TerminalUI
{
  private UserManager userManager;
  
  /// <summary>
  /// Выводит пункты меню в консоль.
  /// </summary>
  public void OpenMainMenu()
  {
    Console.WriteLine(
      "1. Добавить пользователя\n" +
      "2. Удалить пользователя по Id\n" +
      "3. Отобразить список пользователей\n" +
      "0. Выход");
    SelectOperation();
  }

  /// <summary>
  /// Вызывает соответствующий метод в зависимости от выбранного номера меню
  /// </summary>
  private void SelectOperation()
  {
    if (int.TryParse(Console.ReadLine(), out int selectedMenu))
    {
      try
      {
        switch (selectedMenu)
        {
          case 0:
            Environment.Exit(0);
            break;
          case 1:
            AddUser();
            break;
          case 2:
            DeleteUser();
            break;
          case 3:
            PrintUsers();
            break;
        }
      }
      catch (UserAlreadyExistsException ex)
      {
        Console.WriteLine(ex.Message);
      }
      catch (UserNotFoundException ex)
      {
        Console.WriteLine(ex.Message);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        OpenMainMenu();
      }
    }
    else
    {
      SelectOperation();
    }
  }

  /// <summary>
  /// Добавляет нового пользователя по введенным данным
  /// </summary>
  private void AddUser()
  {
    Console.Clear();
    
    Console.WriteLine("Введите Id пользователя");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите имя пользователя");
    string name = Console.ReadLine();
    Console.WriteLine("Введите email пользователя");
    string email = Console.ReadLine();

    User user = new User(id, name, email);
    userManager.AddUser(user);
    
    OpenMainMenu();
  }

  /// <summary>
  /// Удаляет пользователя по Id
  /// </summary>
  private void DeleteUser()
  {
    Console.Clear();
    
    Console.WriteLine("Введите Id удаляемого пользователя");
    int id = int.Parse(Console.ReadLine());
    userManager.RemoveUser(id);
    
    OpenMainMenu();
  }

  
  /// <summary>
  /// Вывод списка пользователей
  /// </summary>
  private void PrintUsers()
  {
    userManager.ListUsers();

    Console.WriteLine("Нажмите любую клавишу чтобы вернуться в меню");
    Console.ReadLine();
    
    OpenMainMenu();
  }

  public TerminalUI(UserManager userManager)
  {
    this.userManager = userManager;
  }
}