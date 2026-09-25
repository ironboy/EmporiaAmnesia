class Janitor : Npc
{
    public bool Bribed = false;

    public Janitor()
    {
        Name = "vaktmästare";
    }

    public override void Interact(Player player)
    {
        if (Bribed)
        {
            Console.WriteLine("\"Varsågod här har du nyckelkortet. Nu drar jag! \"");
            return;
        }
        Menu bribeMenu = new Menu();
        int chosen = bribeMenu.Ask(
            "Jag hittade det här nyckelkortet i en soptunna på toaletten, är det något du är intresserad utav? ",
            ["Ja", "Nej"]
        );
        if (chosen == 2 /*Nej*/)
        {
            Console.WriteLine("\"Jaså inte det...\"");
            Console.WriteLine("\"Då behöver jag din hjälp att städa korridoren . \"");
                    }
        else /* Ja */
        {
            if (player.Backpack.Has("pengar"))
            {

                player.Backpack.Remove("pengar");
                Bribed = true;
                Console.WriteLine("Vaktmästaren tar emot pengarna. \"Nu går jag! \"");
            }

        }

    }
}