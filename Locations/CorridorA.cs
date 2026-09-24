class CorridorA : Location
{
    /*public CorridorA()
    {
        Name = "En lång ödslig korridor";
        Description = "Åt norr ser jag rulltrappan up till taket, åt väster ser jag rulltrappan ner till foajén, åt söder ser utgången till kemtvätten";
    }*/



     // A common convention when naming private fields
    // is naming with and underscore followed but a small letter
    // This makes simple to distinguish from public fields that 
    // you start a capital
    private Janitor _janitor = new();
    public CorridorA()
    {
        Name = "Korridor A";
        Description = "Du är på Korridor A";
        Directions = [Direction.None];
    }

    public override void Interact(Player player)
    {
        // When the player asks to interact with the location
        // then the room can start an interaction with an NPC
        _janitor.Interact(player);
        // Allow to leave if guard is bribed
        if (_janitor.Bribed)
        {
            Directions = Map.DirectionsFor(this);
        }
    }
}