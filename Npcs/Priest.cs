class Priest : Npc
{
    // Remembers if the player said yes to the wedding
    public bool PlayerSaidYes { get; private set; } = false;


    public Priest()
    {
        Name = "Prästen";
    }


    public override void Interact(Player player)
    {
        // Reset the player's answer when the wedding starts
        PlayerSaidYes = false;


        // ==========================================
        // START THE WEDDING
        // ==========================================

        Console.WriteLine();
        Console.WriteLine(
            "Prästen tittar ut över bröllopsgästerna."
        );

        Console.WriteLine();

        Console.WriteLine(
            "\"Vi har samlats här idag för att Player och Partner ska förenas i äktenskap.\""
        );

        Console.WriteLine();

        Console.WriteLine(
            "Prästen vänder sig mot dig."
        );

        Console.WriteLine();

        Console.WriteLine(
            "\"Tager du Partner till din äkta maka?\""
        );


        // ==========================================
        // PLAYER CHOOSES YES OR NO
        // ==========================================

        Menu marriageMenu = new Menu();

        int choice = marriageMenu.Ask(
            "Vad svarar du?",
            [
                "Ja",
                "Nej"
            ]
        );


        // ==========================================
        // PLAYER SAYS YES
        // ==========================================

        if (choice == 1)
        {
            PlayerSaidYes = true;

            Console.WriteLine();
            Console.WriteLine(
                "Player: \"Ja.\""
            );

            Console.WriteLine();

            Console.WriteLine(
                "Prästen vänder sig mot Partner."
            );

            Console.WriteLine();

            Console.WriteLine(
                "\"Tager du Player till din äkta make?\""
            );

            Console.WriteLine();

            Console.WriteLine(
                "Partner: \"Ja.\""
            );

            Console.WriteLine();

            Console.WriteLine(
                "Prästen tittar ut över bröllopsgästerna."
            );

            Console.WriteLine();

            Console.WriteLine(
                "\"Om någon har något att invända mot detta äktenskap, tala nu.\""
            );

            return;
        }


        // ==========================================
        // PLAYER SAYS NO
        // ==========================================

        if (choice == 2)
        {
            PlayerSaidYes = false;

            Console.WriteLine();
            Console.WriteLine(
                "Player: \"Nej.\""
            );

            Console.WriteLine();

            Console.WriteLine(
                "Kyrkan blir helt tyst."
            );

            Console.WriteLine();

            Console.WriteLine(
                "Partnern tittar chockat på dig."
            );

            Console.WriteLine();

            Console.WriteLine(
                "Prästen sänker boken och tittar förvånat på dig."
            );

            return;
        }
    }


    // ==========================================
    // CONTINUE THE WEDDING
    // ==========================================

    // This method is called after the player
    // returns with the divorce papers.
    public void ContinueWedding(Player player)
    {
        Console.WriteLine();
        Console.WriteLine(
            "Prästen vänder sig tillbaka mot brudparet."
        );

        Console.WriteLine();

        Console.WriteLine(
            "\"Efter det lilla avbrottet kan vi fortsätta.\""
        );

        Console.WriteLine();

        Console.WriteLine(
            "\"Skilsmässobeviset visar att det tidigare äktenskapet är avslutat.\""
        );

        Console.WriteLine();

        Console.WriteLine(
            "\"Det finns därför inget som hindrar oss från att fortsätta vigseln.\""
        );

        Console.WriteLine();

        Console.WriteLine(
            "Prästen ler mot er."
        );

        Console.WriteLine();

        Console.WriteLine(
            "\"Jag förklarar er härmed äkta makar.\""
        );

        Console.WriteLine();

        Console.WriteLine(
            "Bröllopsgästerna börjar applådera."
        );

        Console.WriteLine();

        Console.WriteLine(
            "Du och Partner är nu gifta!"
        );


        // End the game after the wedding
        player.GameOver = true;
    }
}