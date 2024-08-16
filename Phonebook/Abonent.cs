namespace Phonebook;

public class Abonent
{
  public string Name { get; private set; }
  public int PhoneNumber { get; private set; }

  public Abonent(string name, int phoneNumber)
  {
    Name = name;
    PhoneNumber = phoneNumber;
  }
}