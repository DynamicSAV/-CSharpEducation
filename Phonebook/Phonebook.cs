// Должна быть реализована CRUD функциональность:
// Должен уметь принимать от пользователя номер и имя телефона.
//   Сохранять номер в файле phonebook.txt. (При завершении программы либо при добавлении).
//   Вычитывать из файла сохранённые номера. (При старте программы).
//   Удалять номера.
//   Получать абонента по номеру телефона.
//   Получать номер телефона по имени абонента.
//   Обращение к Phonebook должно быть как к классу-одиночке.
//   Внутри должна быть коллекция с абонентами.
//   Для обращения с абонентами нужно завести класс Abonent. С полями «номер телефона», «имя».
// Не дать заносить уже записанного абонента.

namespace Phonebook;

public class Phonebook
{
  public static Phonebook instance;
  
  private const string fileName = "phonebook.txt";
  private List<Abonent> abonents = new List<Abonent>();
  private string dockPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
  
  public static Phonebook GetInstance()
  {
    if (instance == null)
      instance = new Phonebook();
    return instance;
  }
  
  /// <summary>
  /// Добавление нового абонента в список
  /// </summary>
  public void Add()
  {
    Console.WriteLine("Введите имя нового абонента");
    string newName = Console.ReadLine();
    
    Console.WriteLine("Введите номер нового абонента");
    int newNumber = int.Parse(Console.ReadLine());

    if (IsContainAbonent(newName) == false)
    {
      Abonent newAbonent = new Abonent(newName, newNumber);
      abonents.Add(newAbonent);
    }
    else
    {
      Console.WriteLine($"Абонент с имененем {newName} уже существует");
    }
    
    Save();
  }

  /// <summary>
  /// Удаление абонента со списка
  /// </summary>
  public void Delete()
  {
    Console.WriteLine("Введите имя абонента который хотите удалить");
    string name = Console.ReadLine();
    
    Abonent abonentForDelete = null;
    foreach (var abonent in abonents)
    {
      if (abonent.Name == name)
      {
        abonentForDelete = abonent;
      }
    }
    abonents.Remove(abonentForDelete);
    Save();
  }

  /// <summary>
  /// Проверка на существование абонента в списке с переданным именем
  /// </summary>
  /// <param name="name"></param>
  /// <returns></returns>
  private bool IsContainAbonent(string name)
  {
    foreach (var abonent in abonents)
    {
      if (abonent.Name == name)
        return true;
    }
    return false;
  }

  /// <summary>
  /// Выводит абонента на консоль
  /// </summary>
  /// <param name="abonent"></param>
  public void PrintAbonent(Abonent abonent)
  {
    Console.WriteLine($"Name: {abonent.Name}, Phone number: {abonent.PhoneNumber}");
  }

  /// <summary>
  /// Вывод списка абонентов на консоль
  /// </summary>
  public void PrintList()
  {
    foreach (Abonent abonent in abonents)
    {
      PrintAbonent(abonent);
    }
  }

  /// <summary>
  /// Получение абонента по имени
  /// </summary>
  public Abonent GetWithName()
  {
    Console.WriteLine("Введите имя абонента: ");
    string name = Console.ReadLine();
    
    foreach (var abonent in abonents)
    {
      if (abonent.Name == name)
      {
        return abonent;
      }
    }
    return null;
  }

  /// <summary>
  /// Получение абонента по номеру
  /// </summary>
  public Abonent GetWithNumber()
  {
    Console.WriteLine("Введите номер абонента: ");
    int number = int.Parse(Console.ReadLine());
    
    foreach (var abonent in abonents)
    {
      if (abonent.PhoneNumber == number)
      {
        return abonent;
      }
    }
    return null;
  }

  /// <summary>
  /// Сохранение списка абонентов в файл
  /// </summary>
  public void Save()
  {
    string text = "";
    foreach (var abonent in abonents)
    {
      text += abonent.Name + ":" + abonent.PhoneNumber + ",";
    }
    File.WriteAllText(Path.Combine(dockPath, fileName), text);
  }

  /// <summary>
  /// Загрузка списка абонентов с файла
  /// </summary>
  public void Load()
  {
    if (!File.Exists(Path.Combine(dockPath, fileName)))
    {
      return;
    }
    
    StreamReader reader = new(Path.Combine(dockPath, fileName));
    string text = reader.ReadToEnd();
    string[] abonentData= text.Split(',');
    
    for (int i = 0; i < abonentData.Length - 1; i++)
    {
      string[] nameAndNumber = abonentData[i].Split(":");
      Abonent newAbonent = new Abonent(nameAndNumber[0], int.Parse(nameAndNumber[1]));
      abonents.Add(newAbonent);
    }
    reader.Close();
  }
}