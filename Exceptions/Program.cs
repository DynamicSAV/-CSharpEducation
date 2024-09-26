namespace Exceptions;

class Program
{
  static void Main(string[] args)
  {
    
    UserManager userManager = new UserManager();
    TerminalUI terminalUi = new TerminalUI(userManager);
    terminalUi.OpenMainMenu();
  }
}