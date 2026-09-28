/// <summary>
/// Used by CorridorA to give the user a keycard that is needed elsewhere.
/// </summary>
class Janitor : Npc
{
    public bool Bribed { get; private set; } = false;
    public bool Helped { get; private set; } = false;
    public bool KeycardGiven { get; private set; } = false;

    public Janitor()
    {
        Name = "Vaktmästare";
    }


    public override void Interact(Player player)
    {
        // If you've been given the keycard once, you can't get it again if you lost it.
        if (KeycardGiven)
        {
            Console.WriteLine("Vaktmästaren har redan gett dig nyckelkortet.");
            return;
        }

        // If you already have the keycard, you're done here. Move on.
        if (player.Backpack.Has("keycard"))
        {
            Console.WriteLine("Du har redan nyckelkortet.");
            return;
        }

        // You've earned the keycard. There you go.
        if (Bribed || Helped)
        {
            GiveKeycard(player);
            return;
        }

        Menu bribeMenuJanitor = new Menu();
        int chosen = bribeMenuJanitor.Ask(
            "Vaktmästaren: Jag hittade det här nyckelkortet i en soptunna på toaletten, är det något du är intresserad utav? \n Det kommer kosta dig en slant. ",
            ["Ja", "Nej"]
        );

        // Om din Ask-metod returnerar 1-indexerat svar:
        // Ja = 1
        // Nej = 2
        if (chosen == 1)
        {
            if (player.Backpack.Has("pengar"))
            {
                player.Backpack.Remove("pengar");
                Bribed = true;

                Console.WriteLine("Vaktmästaren tar emot pengarna. \"Nu går jag!\"");
                GiveKeycard(player);
            }
            else
            {
                Console.WriteLine("Du har inga pengar att ge.");
            }
        }
        else
        {
            Console.WriteLine("\"Jaså inte det...\"");
            Console.WriteLine("\"Om du ändå vill ha nyckelkortet så behöver jag din hjälp att städa korridoren.\"");

            Menu helpMenuJanitor = new Menu();
            int helpChoice = helpMenuJanitor.Ask(
                "Vill du hjälpa till och städa korridoren?",
                ["Ja", "Nej"]
            );

            if (helpChoice == 1)
            {
                Console.Write("Du städar korridoren för vaktmästaren.");
                Wait.Waiting(10000, 1000, WaitAnimationType.Dots, true);
                Console.WriteLine("Nu är korridoren skinande ren, bra jobbat.");
                Helped = true;
                GiveKeycard(player);
            }
            else
            {
                Console.WriteLine("Vaktmästaren ser inte nöjd ut och du går därifrån tomhänt.");
            }
        }
    }

    private void GiveKeycard(Player player)
    {
        if (KeycardGiven)
        {
            return;
        }

        if (player.Backpack.Has("keycard"))
        {
            Console.WriteLine("Du har redan nyckelkortet.");
            return;
        }

        Console.WriteLine("Vaktmästaren ger dig nyckelkortet. \"Nu drar jag!\"");
        player.Backpack.Add(new Keycard());
        KeycardGiven = true;
    }
}
