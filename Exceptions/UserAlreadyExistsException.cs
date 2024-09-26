namespace Exceptions;

public class UserAlreadyExistsException : Exception
{
  public UserAlreadyExistsException(int id) : base($"Пользователь с Id: {id} уже существует")
  { }
}