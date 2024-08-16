namespace Phonebook;

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

class Program
{
  static void Main(string[] args)
  {
    Phonebook phonebook = Phonebook.GetInstance();
    //Загруска
    phonebook.Load();
    //Добавление и сохранение
    phonebook.Add();
    phonebook.Add();
    //Удаление
    phonebook.Delete();
    //Получение по имени
    Abonent result = phonebook.GetWithName();
    if (result == null)
      Console.WriteLine("Абонент не найден");
    else
    {
      phonebook.PrintAbonent(result);
    }
    //Получение по номеру
    Abonent result1 = phonebook.GetWithNumber();
    if (result1 == null)
      Console.WriteLine("Абонент не найден");
    else
    {
      phonebook.PrintAbonent(result1);
    }
    //Вывод списка
    Console.WriteLine("Список абонентов");
    phonebook.PrintList();
    //phonebook.PrintList();
    phonebook.Save();
  }
}