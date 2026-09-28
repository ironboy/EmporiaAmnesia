class Escalator1 : Location
{
    public Escalator1()
    {
        Name = "Övre rulltrappan";
        Description = "Du måste interagera för att använda rulltrappan. Jag ser en korridor söderut och taket österut. Rulltrappan går uppåt. Om du vill ner, så får du springa.";

        // Forces the user to interact with the escalator
        Directions = [Direction.None];
    }

    /// <summary>
    /// Interact is used instead of Game.ChooseDirection() for the escalator
    /// </summary>
    /// <param name="player"></param>
    public override void Interact(Player player)
    {
        int chosen = new Menu().Ask("Vill du åka upp till taket eller ner till den övre korridoren? ", ["Upp", "Ner"]);

        if (chosen == 1)
        {
            Console.Write("Njut av åkturen upp till taket...");

            // Wait 4 seconds while animating with 1 spinning character every second
            Wait.Waiting(4000, 1000, WaitAnimationType.DashSlashPipe, true);
            player.Col++;
        }
        else
        {
            Console.Write("Spring, spring, spring fort, så du hinner ner till den övre korridoren...");

            // Wait 10 seconds while animating with 5 spinning characters every 200 milliseconds
            Wait.Waiting(10000, 200, WaitAnimationType.DashSlashPipe, true, 5);
            player.Row++;
        }
    }
}