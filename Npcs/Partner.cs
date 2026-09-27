// The partner owns this part of the wedding conversation.
class Partner : Npc
{
    private const string DivorceCertificateItem = "skilsmässobevis";

    public Partner()
    {
        Name = "Partnern";
    }

    public void Interact(Player player, bool dramaHasStarted)
    {
        // This plays out, when you've already interacted at the Altar at least once 
        //Here is when dramaHasStarted = true
        if (dramaHasStarted)
        {
            Console.WriteLine("Partnern står vid altaret och ser jätteorolig ut.");
            Console.WriteLine("Fick du tag på skilsmässobeviset?");

            int choice = new Menu().Ask(
                "Vad svarar du?",
                [
                "Ja, jag hittade den.",
                "Nej, jag är ledsen jag hittade inte den."
                ]
            );

            if (choice == 1)
            {
                if (player.Backpack.Has(DivorceCertificateItem))
                {
                    Console.WriteLine("Vad bra, du hittade skilsmässobeviset.");
                    Console.WriteLine("Gå tillbaka till vigseln när ni är redo.");
                    return;
                }

                Console.WriteLine("Jag ser inte skilsmässobeviset i din ryggsäck.");
                Console.WriteLine("Du behöver hitta det innan ni kan gifta er.");
                return;
            }

            Console.WriteLine("Då får vi vänta. Hitta skilsmässobeviset innan vigseln fortsätter.");
            return;
        }
        else
        {
            // This plays out when you interact at the altar for the first time
            // Here is when dramaHasStarted = false
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

    // This plays out when you interact at the altar for the first time
    // Here is when dramaHasStarted = false
    public override void Interact(Player player)
    {
        Interact(player, false);
    }

}