namespace Exceptions;

public class UserManager
{
  public List<User> Users = new List<User>();

  /// <summary>
  /// Добавляет нового пользователя в список
  /// </summary>
  /// <param name="user"></param>
  /// <exception cref="UserAlreadyExistsException"></exception>
  public void AddUser(User user)
  {
    User? foundedUser = Users.FirstOrDefault(u => u.Id == user.Id);
    
    if (foundedUser == null)
      Users.Add(user);
    else
      throw new UserAlreadyExistsException(user.Id);
  }

  /// <summary>
  /// Удаляет пользователя по Id
  /// </summary>
  /// <param name="id"></param>
  public void RemoveUser(int id)
  {
    User userToRemove = GetUser(id);
    Users.Remove(userToRemove);
  }

  /// <summary>
  /// Возвращает пользователя по Id
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  /// <exception cref="UserNotFoundException"></exception>
  public User GetUser(int id)
  {
    User? foundedUser = Users.FirstOrDefault(user => user.Id == id);
    if (foundedUser == null)
      throw new UserNotFoundException(id);
    return foundedUser;
  }

  /// <summary>
  /// Выводит список пользователей на консоль
  /// </summary>
  public void ListUsers()
  {
    foreach (var user in Users)
    {
      Console.WriteLine(user);
    }
  }
}