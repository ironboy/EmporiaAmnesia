// The partner owns this part of the wedding conversation.
class Partner : Npc
{
    public Partner()
    {
        Name = "Partnern";
    }

    public override void Interact(Player player)
    {
        Console.WriteLine("Partnern står vid altaret och ser orolig ut.");
        Console.WriteLine("Partnern tittar på dig.");
        Console.WriteLine("\"Är det sant? Är ni fortfarande gifta?\"");

        // Menu.Ask returns the selected option as a 1-based number.
        int choice = new Menu().Ask(
            "Vad gör du?",
            [
                "Jag hämtar skilsmässobeviset.",
                "Jag hämtar INTE skilsmässobeviset."
            ]
        );

        if (choice == 1)
        {
            // The player must fetch the divorce certificate before continuing.
            Console.WriteLine("\"Det är inte sant! Jag ska hämta skilsmässobeviset.\"");
            Console.WriteLine("Du måste hämta skilsmässobeviset innan vigseln kan fortsätta.");
            return;
        }

        // GameOver tells Game to stop the main loop after this interaction.
        Console.WriteLine("GAME OVER!");
        player.GameOver = true;
    }
}