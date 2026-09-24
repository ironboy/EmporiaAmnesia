class SurveillanceRoom : Location
{
    // Vi skapade enums för kamerorna som användaren kan se övervakningarna ifrån.  
    private enum Camera
    {
        DryCleaner,
        Entrance,
        Escalator,
        Toilets,
        Entrance2,
        Toilets2
    }

    // Skapade en lista av övervakningskameror. Om man ej kollar genom alla filmer, får man inte tillbaka minnet.
    private List<Camera> _watched = [];
    // ska skapa remember metod som ska leda till att användaren får tillbaka sina minnen 
    private bool _remembered = false;

    public SurveillanceRoom()
    {
        Name = "Övervakningsrummet";
        Description = "Ett mörkt rum som luktar gammalt kaffe. En vägg av skärmar och en dator "
            + "med nattens inspelningar. Dörren västerut är låst från andra sidan.";
        // Man kan bara gå norrut.
        Directions = [Direction.North];
    }

}