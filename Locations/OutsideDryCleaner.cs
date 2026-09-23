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
            player.Row = 3;   // the security office, see Map.cs
            player.Col = 3;
        }
    }
}