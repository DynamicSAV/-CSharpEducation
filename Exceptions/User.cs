namespace Exceptions;

public class User
{
  public int Id;
  public string Name;
  public string Email;

  public User(int id, string name, string email)
  {
    this.Id = id;
    this.Name = name;
    this.Email = email;
  }

  public override string ToString()
  {
    return $"Id: {Id}\n" +
           $"Name: {Name}\n" +
           $"Email: {Email}\n";
  }
}