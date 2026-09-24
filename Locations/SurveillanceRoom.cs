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
        Console.WriteLine($"\n[{Label(camera)}]");
        switch (camera)
        {
            case Camera.DryCleaner:
                Console.WriteLine("Du står vid disken och lämnar in en kostym. Rödvin över hela kavajen.");
                Console.WriteLine("Du pekar på klockan och håller upp ett finger: Du ska hämta den om 1 timme. Kemtvättaren nickar.");
                break;
            case Camera.Entrance:
                Console.WriteLine("Dörrarna glider upp. In kommer du, arm i arm med en man i fluga.");
                Console.WriteLine("Ni ser fulla ut och du bär en spritflaska...");
                break;
            case Camera.Escalator:
                Console.WriteLine("Du försöker gå uppför rulltrappan åt fel håll. Mannen i fluga drar ner dig skrattandes.");
                Console.WriteLine("Han tar fram en bunt sedlar, pekar på dig och säger något.");
                Console.WriteLine("Du ler brett och ger honom en kram. Han går tillbaka mot entren efter att ha pekat dig i riktningen mot rätt rulltrappa.");
                break;
            case Camera.Toilets:
                Console.WriteLine("Du springer in i toalettbåsen med handen över munnen.");
                Console.WriteLine("Du snubblar en gång men går snabbt upp och öppnar toalettbåsens dörr hastigt.");
                break;
                case Camera.Entrance2:
                Console.WriteLine("Mannen i flugan blir mött av en säkerhetsvakt vid entren.");
                Console.WriteLine("Säkerhetsvakten pekar på sin klocka medan han eskorterar ut mannen i flugan.");
                break;
            case Camera.Toilets2:
                Console.WriteLine("Du ser dig själv komma ut långsamt, vinglandes och förrvirrad över hur du hamnade där.");                
                break;
        }
    }


// När alla filmer har setts, flöder vårt minne tillbaka.
    private void Remember()
    {
        Console.WriteLine("\nBilderna faller på plats. Mannen i fluga är din bästa vän och best man.");
        Console.WriteLine("Ni var på svensexan. Pengarna var hans present: Till smekmånaden.");
    }
}
