class OutsideDryCleaner : Location
{
    private int attempts = 0;
    // Remembers if the lock has been opened, so we don't ask for the code again
    private bool isOpen = false;

    public OutsideDryCleaner()
    {
        Name = "Utanför kemtvätten";
        Description = "En glasdörr med ett kodlås. Kemtvätten är mörk där inne.";
        // South (the dry cleaner) is hidden until the lock is opened
        Directions = [Direction.North, Direction.East];
    }

    public override void Interact(Player player)
    {

        if (isOpen)
        {
            Console.WriteLine("Dörren står redan öppen, kemtvätten ligger söderut");
            return;
        }

        Console.Write("Slå in koden: ");
        string? code = Console.ReadLine();
        if (code == "5361")
        {
            isOpen = true;
            Directions = Map.DirectionsFor(this);
            Console.WriteLine("Låset klickar. Dörren glider upp.");
            Description = "Glasdörren till kemtvätten står öppen.";
            return;
        }
        attempts++;
        Console.WriteLine($"Fel kod. Försök {attempts} av 3.");
        if (attempts == 3)
        {
            Console.WriteLine("LARM! En vakt kommer springande och släpar iväg dig.");
            // This how you "teleport" the player to a different location
            // based on the map coordinates, 3, 3 is the security office
            //player.Teleport(3, 3);
            attempts = 0;
            player.Teleport("SecurityOffice");
        }
    }
}