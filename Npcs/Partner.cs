class Partner : Npc
{
    public Partner()
    {
        Name = "Partnern";
    }

    public override void Interact(Player player)
    {
        Console.WriteLine("Partnern tittar på dig.");
        Console.WriteLine("\"Är det sant? Är ni fortfarande gifta?\"");

        Menu weddingMenu = new();

        int chosen = weddingMenu.Ask(
            "Vad gör du?",
            [
                "Jag hämtar skilsmässobeviset.",
                "Jag erkänner att påståendet stämmer."
            ]
        );

        if (chosen == 1)
        {
            Console.WriteLine(
                "\"Det är inte sant! Jag ska hämta skilsmässobeviset.\""
            );

            Console.WriteLine(
                "Du måste hämta skilsmässobeviset innan vigseln kan fortsätta."
            );
        }
        else
        {
            Console.WriteLine(
                "\"Hon har rätt. Vi är fortfarande gifta...\""
            );

            player.GameOver = true;
        }
    }
}