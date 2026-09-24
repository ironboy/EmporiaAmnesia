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
            Console.WriteLine("\"Jag har inte sett dig. Gå nu.\"");
            return;
        }
        Menu bribeMenu = new Menu();
        int chosen = bribeMenu.Ask(
            "Om du har pengar skulle vi kunna prata om en lösning...",
            ["Ja", "Nej"]
        );
        if (chosen == 2 /*Nej*/)
        {
            Console.WriteLine("\"Jaså inte det...\"");
            Console.WriteLine("\"Du sitter här tills polisen kommer.\"");
            player.GameOver = true;
        }
        else /* Ja */
        {
            if (player.Backpack.Has("pengar"))
            {

                player.Backpack.Remove("pengar");
                Bribed = true;
                Console.WriteLine("Vakten stoppar på sig bunten. \"Vilket larm?\"");
            }
            else
            {
                Console.WriteLine("\"Du ljuger - jag har muddrat dig. Inga pengar!");
                Console.WriteLine("\"Du sitter här tills Vakten kommer.\"");
                player.GameOver = true;
            }
        }

    }
}