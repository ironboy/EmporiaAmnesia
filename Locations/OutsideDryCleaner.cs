class OutsideDryCleaner : Location
{
    private int attempts = 0;

    public OutsideDryCleaner()
    {
        Name = "Utanför kemtvätten";
        Description = "En glasdörr med ett kodlås. Kemtvätten är mörk där inne.";
        Directions = [Direction.North, Direction.South, Direction.East];
    }

    public override void Interact(Player player)
    {
        Console.Write("Slå in koden: ");
        string? code = Console.ReadLine();
        if (code == "1234")
        {
            Console.WriteLine("Låset klickar. Dörren glider upp.");
            return;
        }
        attempts++;
        Console.WriteLine($"Fel kod. Försök {attempts} av 3.");
        if (attempts == 3)
        {
            Console.WriteLine("LARM! En vakt kommer springande och släpar iväg dig.");
            // This how you "teleport" the player to a different location
            // based on the map coordinates, 3, 3 is the security office
            player.Teleport(3, 3);
        }
    }
}