namespace EmployeeAccountingSystem;

public interface IEmployeeManager<T>
{
  /// <summary>
  /// Добавляет нового сотрудника.
  /// </summary>
  /// <param name="employee">Сотрудник, который будет добавлен.</param>
  public void Add(T employee);
  
  /// <summary>
  /// Получает сотрудника по имени.
  /// </summary>
  /// <param name="name">Имя сотрудника, которого нужно найти.</param>
  public T Get(string name);
  
  /// <summary>
  /// Обновляет информацию о существующем сотруднике.
  /// </summary>
  /// <param name="employee">Сотрудник с обновленной информацией.</param>
  public void Update(T employee);
}