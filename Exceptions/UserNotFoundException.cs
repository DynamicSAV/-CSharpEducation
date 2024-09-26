namespace Exceptions;

public class UserNotFoundException : Exception
{
  public UserNotFoundException(int id) : base($"Пользователь с id {id} не найден.")
  {
  }
}