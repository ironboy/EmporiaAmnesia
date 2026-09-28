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
            case Camera.Entrance: return "Kamera 2: Entrén, 19:47";
            case Camera.Escalator: return "Kamera 3: Rulltrappan, 19:55";
            case Camera.Toilets: return "Kamera 4: Toaletterna, 19:58";
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
                Console.WriteLine("Du står vid disken. Din vän i fluga skrattar medan du lämnar in en kostym täckt i rödvin.");
                Console.WriteLine("Vännen betalar för expresstvätt, tar emot kvittot och stoppar ner det i sin ryggsäck.");
                Console.WriteLine("Du pekar på klockan och håller upp ett finger: Ni ska hämta den om 1 timme. Kemtvättaren nickar stressat.");
                break;
            case Camera.Entrance:
                Console.WriteLine("Dörrarna glider upp. Du och mannen i fluga stapplar in igen.");
                Console.WriteLine("Ni är uppenbart berusade. Han bär ryggsäcken, och du dricker ur en spritflaska...");
                break;
            case Camera.Escalator:
                Console.WriteLine("Ni står vid rulltrapporna när ni får syn på en säkerhetsvakt. Mannen i fluga kollar på sin klocka, verkar få panik.");
                Console.WriteLine("Han tar av sig ryggsäcken, stoppar ner en tjock sedelbunt i den och hänger den på din rygg.");
                Console.WriteLine("Han pekar upp mot kemtvätten, ger dig en snabb kram och springer sedan skrikandes åt andra hållet för att avleda vakten.");
                break;
            case Camera.Toilets:
                Console.WriteLine("Du är på väg mot kemtvätten, men stannar plötsligt. Spriten har slagit till på riktigt.");
                Console.WriteLine("Du slår handen över munnen, ser grön ut i ansiktet och springer snublandes med ryggsäcken på ryggen in på toaletterna.");
                break;
                case Camera.Entrance2:
                Console.WriteLine("Mannen i fluga har blivit fångad av säkerhetsvakten vid entrén.");
                Console.WriteLine("Vakten pekar argt på sin klocka och kastarut din vän genom dörrarna.");
                break;
            case Camera.Toilets2:
                Console.WriteLine("Emporia är nu nedsläckt och låst.");
                Console.WriteLine("Du ser dig själv komma ut långsamt, vinglandes och förrvirrad över hur du hamnade där.");
                break;
        }
    }


// När alla filmer har setts, flöder vårt minne tillbaka.
    private void Remember()
    {
        Console.WriteLine("\nBilderna faller på plats. Mannen i fluga är din bästa vän och best man.");        
        Console.WriteLine("Han råkade spilla rödvin på din kostym under svensexan, så ni åkte till Emporia för att paniktvätta den.");
        Console.WriteLine("Pengarna i ryggsäcken är dina vänners present till bröllopsresan.");
        Console.WriteLine("När vakten skulle kasta ut er vid stängning offrade han sig så att du skulle hinna hämta kostymen...");
        Console.WriteLine("...men istället däckade du på toaletten. Med hans ryggsäck, kvittot och alla pengarna.");
        Console.WriteLine("\nBröllopet är idag. Och du måste ut härifrån.");
    }
}
