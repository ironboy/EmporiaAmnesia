class Escalator2 : Location
{
  public Escalator2()
  {
    Name = "Nedre rulltrappan";
    Description = "Du måste interagera för att använda rulltrappan. Jag ser en foajé västerut och en korridor österut. Rulltrappan går neråt, om du vill upp, så får du springa.";

    // Forces the user to interact with the escalator
    Directions = [Direction.None];
  }

  /// <summary>
  /// Interact is used instead of Game.ChooseDirection() for the escalator
  /// </summary>
  /// <param name="player"></param>
  public override void Interact(Player player)
  {
    int chosen = new Menu().Ask("Vill du åka upp till den övre korridoren eller ner till foajén? ", ["Upp", "Ner"]);

    if (chosen == 1)
    {
      Console.Write("Spring, spring, spring fort, så du hinner upp till den övre korridoren...");

      // Wait 10 seconds while animating with 5 spinning characters every 200 milliseconds
      Wait.Waiting(10000, 200, WaitAnimationType.DashSlashPipe, true, 5);
      player.Col++;
    }
    else
    {
      Console.Write("Njut av åkturen ner till foajén...");

      // Wait 4 seconds while animating with 1 spinning character every second
      Wait.Waiting(4000, 1000, WaitAnimationType.DashSlashPipe, true);
      player.Col--;
    }
  }
}