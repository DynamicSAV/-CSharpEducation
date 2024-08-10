using System.Diagnostics;

namespace Task2;

public class TicTacToe
{
  private string[] gameGrid = new string[9];
  private int currentTurn = 0;
  private bool isXTurn;
  private bool isEndGame = false;

  private const string firstPlayer = "X";
  private const string secondPlayer = "O";

  /// <summary>
  /// Документация
  /// </summary>
  public void StartGameCycle()
  {
    CreateGrid();
    PrintGrid();
    while (currentTurn < 9 && isEndGame == false)
    {
      GetNextPlace();
      PrintGrid();
      CheckWin();
    }
  }

  /// <summary>
  /// Заполнение игрового массива
  /// </summary>
  private void CreateGrid()
  {
    for (var i = 0; i < gameGrid.Length; i++) gameGrid[i] = i + 1 + "";
  }

  //Начальная версия без цвета
  /*private void PrintGrid()
  {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("-------------");
      Console.WriteLine($"| {gameGrid[0]} | {gameGrid[1]} | {gameGrid[2]} |");
      Console.WriteLine("-------------");
      Console.WriteLine($"| {gameGrid[3]} | {gameGrid[4]} | {gameGrid[5]} |");
      Console.WriteLine("-------------");
      Console.WriteLine($"| {gameGrid[6]} | {gameGrid[7]} | {gameGrid[8]} |");
      Console.WriteLine("-------------");
  }*/

  /// <summary>
  /// Вывод игрового поля в консоль
  /// </summary>
  private void PrintGrid()
  {
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("-------------");
    PrintStroke(0, 2);
    Console.WriteLine("-------------");
    PrintStroke(3, 5);
    Console.WriteLine("-------------");
    PrintStroke(6, 8);
    Console.WriteLine("-------------");
  }

  /// <summary>
  /// Вывод строки игрового поля
  /// </summary>
  /// <param name="start"></param>
  /// <param name="end"></param>
  private void PrintStroke(int start, int end)
  {
    Console.Write("| ");

    for (var i = start; i <= end; i++)
    {
      PrintPaintedElement(i);
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write(" | ");
    }

    Console.Write("\n");
  }

  /// <summary>
  /// Изменение цвета печати в консоли
  /// </summary>
  /// <param name="index"></param>
  private void PrintPaintedElement(int index)
  {
    if (gameGrid[index] == firstPlayer)
      Console.ForegroundColor = ConsoleColor.Red;
    else if (gameGrid[index] == secondPlayer)
      Console.ForegroundColor = ConsoleColor.Blue;
    else
      Console.ForegroundColor = ConsoleColor.White;

    Console.Write(gameGrid[index]);
  }

  /// <summary>
  /// Воод координат следующего хода
  /// </summary>
  private void GetNextPlace()
  {
    var isCorrectEnter = false;
    string coordinate;

    currentTurn++;
    isXTurn = !isXTurn;

    while (isCorrectEnter == false)
    {
      Console.WriteLine(isXTurn ? $"Ход {firstPlayer}: " : $"Ход {secondPlayer}: ");

      coordinate = Console.ReadLine();

      if (coordinate != null && IsCorrectCoordinate(coordinate))
      {
        isCorrectEnter = true;
        PlaceElement(coordinate);
      }
      else
      {
        Console.WriteLine("Неверный ход!");
      }
    }
  }

  /// <summary>
  /// Запись хода игрока в массив
  /// </summary>
  /// <param name="coordinate"></param>
  private void PlaceElement(string coordinate)
  {
    if (isXTurn)
      PlaceX(int.Parse(coordinate));
    else
      PlaceO(int.Parse(coordinate));
  }

  /// <summary>
  /// Проверка валидности координаты
  /// </summary>
  /// <param name="value"></param>
  /// <returns></returns>
  private bool IsCorrectCoordinate(string value)
  {
    if (value == "" || value.Length > 1) return false;

    if (int.TryParse(value, out var coordinate))
    {
      if (gameGrid[coordinate - 1] == firstPlayer || gameGrid[coordinate - 1] == secondPlayer) return false;
    }
    else
    {
      return false;
    }

    return coordinate <= 9;
  }

  /// <summary>
  /// Размещение хода первого игрока
  /// </summary>
  /// <param name="coordinate"></param>
  private void PlaceX(int coordinate)
  {
    gameGrid[coordinate - 1] = firstPlayer;
  }

  /// <summary>
  /// Размещение хода второго игрока
  /// </summary>
  /// <param name="coordinate"></param>
  private void PlaceO(int coordinate)
  {
    gameGrid[coordinate - 1] = secondPlayer;
  }

  /// <summary>
  /// Проверка на победу и ничью
  /// </summary>
  private void CheckWin()
  {
    if ((gameGrid[1] == gameGrid[0] && gameGrid[0] == gameGrid[2]) // верхний горизонт
        || (gameGrid[6] == gameGrid[7] && gameGrid[7] == gameGrid[8]) // нижний горизонт
        || (gameGrid[3] == gameGrid[0] && gameGrid[3] == gameGrid[6]) // левая вертикаль
        || (gameGrid[5] == gameGrid[2] && gameGrid[5] == gameGrid[8]) // правая вертикаль
        || (gameGrid[1] == gameGrid[4] && gameGrid[4] == gameGrid[7]) // середина вертикаль
        || (gameGrid[3] == gameGrid[4] && gameGrid[4] == gameGrid[5]) // середина горизонталь
        || (gameGrid[0] == gameGrid[4] && gameGrid[4] == gameGrid[8]) // главная диагональ
        || (gameGrid[2] == gameGrid[4] && gameGrid[4] == gameGrid[6])) // побочная диагональ
      isEndGame = true;

    if (isEndGame)
      Console.WriteLine(isXTurn ? $"{firstPlayer} победил" : $"{secondPlayer} победил");
    else if (currentTurn == 9) Console.WriteLine("Ничья");
  }
}