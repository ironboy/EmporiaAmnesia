class Menu
{
  // Menu does not know what the options mean. It prints them numbered,
  // waits for a valid number and returns the player's choice (1 = first option).
  public int Ask(string heading, List<string> options)
  {
    Console.WriteLine($"\n== {heading}");
    for (int i = 0; i < options.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {options[i]}");
    }
    while (true)
    {
      Console.Write("> ");
      string? input = Console.ReadLine();
      if (int.TryParse(input, out int choice) && choice >= 1 && choice <= options.Count)
      {
        return choice;
      }
      Console.WriteLine("Välj ett av numren i menyn.");
    }
  }
}
