class Janitor : Npc
{
    public bool Bribed = false;
    public bool Helped = false;
    public bool KeycardGiven = false;

    public Janitor()
    {
        Name = "Vaktmästare";
    }
    

    public override void Interact(Player player)
    {
        if (KeycardGiven)
        {
            Console.WriteLine("Vaktmästaren har redan gett dig nyckelkortet.");
            return;
        }

        if (player.Backpack.Has("keycard"))
        {
            Console.WriteLine("Vaktmästaren säger att han redan gett dig nyckelkortet. ");
            return;
        }

        if (Bribed || Helped)
        {
            GiveKeycard(player);
            return;
        }

        Menu bribeMenuJanitor = new Menu();
        int chosen = bribeMenuJanitor.Ask(
            "Jag hittade det här nyckelkortet i en soptunna på toaletten, är det något du är intresserad utav? \n Det kommer kosta dig en slant. ",
            new[] { "Ja", "Nej" }
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
            Console.WriteLine("\"Då behöver jag din hjälp att städa korridoren.\"");

            Menu helpMenuJanitor = new Menu();
            int helpChoice = helpMenuJanitor.Ask(
                "Vill du hjälpa till och städa korridoren?",
                new[] { "Ja", "Nej" }
            );

            if (helpChoice == 1)
            {
                Console.WriteLine("Du städar korridoren för vaktmästaren.");
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

        player.Backpack.Add(new Keycard());
        KeycardGiven = true;

        Console.WriteLine("Vaktmästaren ger dig nyckelkortet. \"Nu drar jag!\"");
    }
}
