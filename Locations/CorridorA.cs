class CorridorA : Location
{
    // A common convention when naming private fields
    // is naming with and underscore followed but a small letter
    // This makes simple to distinguish from public fields that
    // you start a capital
    private Janitor _janitor = new();
    public CorridorA()
    {
        Name = "Övre korridoren";
        Description = "Här finns en vaktmästare som vill ha din uppmärksamhet.";
        Directions = [Direction.None];
    }

    public override void Interact(Player player)
    {
        // When the player asks to interact with the location
        // then the room can start an interaction with an NPC
        _janitor.Interact(player);
        // Allow to leave if guard is bribed
        if (_janitor.Bribed || _janitor.Helped)
        {
            Directions = Map.DirectionsFor(this);
            Description = "Åt norr ser jag rulltrappan upp till taket, åt väster ser jag rulltrappan ner till foajén, åt söder ser jag utgången till kemtvätten.";
        }
    }
}