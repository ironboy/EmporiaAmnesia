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
// interact metod som ger användaren möjlighet att välja övervakningskamera. eller ställa dig upp
    public override void Interact(Player player)
    {
        Console.WriteLine("Du sätter dig vid datorn. Inspelningarna från i natt är sorterade efter kamera.");
        int choice = new Menu().Ask(
            "Vilken kamera vill du se?",
            [
                Label(Camera.DryCleaner),
                Label(Camera.Entrance),
                Label(Camera.Escalator),
                Label(Camera.Toilets),
                Label(Camera.Entrance2),
                Label(Camera.Toilets2),
                "Gå från datorn"
            ]
        );
        if (choice == 7)
        {
            Console.WriteLine("Du reser dig från stolen. Skärmarna surrar vidare.");
            return;
        }

        Camera camera = (Camera)(choice - 1);
        Play(camera);

        if (!_watched.Contains(camera))
        {
            _watched.Add(camera);
        }
        // bool blir sann när alla filmer har kollats och minnet kommer tillbaka 
        if (_watched.Count == 6 && !_remembered)
        {
            _remembered = true;
            Remember();
        }
    }
    // vi använder switch case för spela det valda allternativet 
    private static string Label(Camera camera)
    {
        switch (camera)
        {
            case Camera.DryCleaner: return "Kamera 1: Kemtvätten, 18:30";
            case Camera.Entrance: return "Kamera 2: Entrén, 19:40";
            case Camera.Escalator: return "Kamera 3: Rulltrappan, 19:45";
            case Camera.Toilets: return "Kamera 4: Toaletterna, 19:55";
            case Camera.Entrance2: return "Kamera 2: Entrén, 19:59"; //Filmer med "2" i namnet visar vad som hände senare på samma plats.
            case Camera.Toilets2: return "Kamera 4: Toaletterna, 01:16";
            default: return camera.ToString();
        }
    }

private void Play(Camera camera)
    {
        
    }

// När alla filmer har setts, flöder vår minne tillbaka.
    private void Remember()
    {
        Console.WriteLine("\nBilderna faller på plats. Mannen i fluga är din bästa vän och best man.");
        Console.WriteLine("Ni var på svensexan. Pengarna var hans present: Till smekmånaden.");
    }
}
