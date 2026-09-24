class SecurityOffice : Location
{
    // A common convention when naming private fields
    // is naming with and underscore followed but a small letter
    // This makes simple to distinguish from public fields that 
    // you start a capital
    private Guard _guard = new();
    public SecurityOffice()
    {
        Name = "Säkerhetsvakternas kontor";
        Description = "Ett trångt kontor utan fönster. En vakt sitter bakom ett skrivbord fullt av skärmar. "
            + "Dörren bakom dig är låst"; 
        Directions = [Direction.None];
    }

      public override void Interact(Player player)
    {
        // Until the guard is bribed, the only thing to do here is to talk to him
        if (!_guard.Bribed)
        {
            Console.WriteLine(_guard);
            _guard.Interact(player);
            
            if (_guard.Bribed)
            {
                Directions = [Direction.North, Direction.South, Direction.East];
                Description = "Ett trångt kontor utan fönster. Vakten har vänt ryggen till och låtsas inte se dig. "
                    + "En dörr söderut står på glänt.";
            }
            return;
        }

        int choice = new Menu().Ask("Vad gör du?", ["Prata med vakten", "Titta på skärmarna"]);
        if (choice == 1)
        {
            _guard.Interact(player);
        }
        else
        {
            WatchScreens();
        }
    }

    private void WatchScreens()
    {
        Console.WriteLine("Skärmarna flimrar. Tomma korridorer, en stängd rulltrappa.");
        Console.WriteLine("På parkeringsdäcket står en kvinna i hatt och röker. Hon tittar på klockan, igen och igen.");
        Console.WriteLine("Vakten muttrar: \"Hon har gått runt och letat efter någon hela morgonen.\"");
    }
}