class Church : Location
{
    public Church()
    {
        Name = "Kyrkan";

        Description =
            "En vacker kyrka förberedd för ett bröllop. " +
            "Längst fram finns altaret där vigseln ska äga rum. " +
            "Prästen och din partner väntar längre fram, " +
            "medan exet sitter längre bak bland bröllopsgästerna.";

        // The altar is south of the church
        Directions = [Direction.South, Direction.North];
    }

    public override void Interact(Player player)
    {
        Console.WriteLine();
        Console.WriteLine("Du står inne i kyrkan.");

        Console.WriteLine(
            "Längre fram ser du altaret där prästen och partnern väntar."
        );

        Console.WriteLine(
            "Exet sitter längre bak bland bröllopsgästerna."
        );

        Console.WriteLine();

        Menu churchMenu = new Menu();

        int choice = churchMenu.Ask(
            "Vad vill du göra?",
            [
                "Gå fram till altaret",
                "Gå tillbaka till kyrkporten"
            ]
        );


        // ==========================================
        // GO TO THE ALTAR
        // ==========================================

        if (choice == 1)
        {
            Console.WriteLine();
            Console.WriteLine(
                "Du bestämmer dig för att fortsätta med bröllopet."
            );

            Console.WriteLine(
                "Du går genom kyrkan och fram mot altaret."
            );

            player.Teleport("Altar");

            return;
        }


        // ==========================================
        // GO TO THE CHURCH GATE
        // ==========================================

        if (choice == 2)
        {
            Console.WriteLine();
            Console.WriteLine(
                "Du går tillbaka mot den stora kyrkporten."
            );

            Menu doorMenu = new Menu();

            int doorChoice = doorMenu.Ask(
                "Vill du öppna kyrkporten?",
                [
                    "Ja",
                    "Nej"
                ]
            );


            // Player does not open the gate
            if (doorChoice == 2)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Du bestämmer dig för att inte öppna kyrkporten."
                );

                return;
            }


            // ==========================================
            // OPEN THE GATE
            // ==========================================

            Console.WriteLine();
            Console.WriteLine(
                "Du tar tag i den stora kyrkporten."
            );

            Console.WriteLine(
                "Porten knarrar när den långsamt öppnas."
            );

            Console.WriteLine();
            Console.WriteLine(
                "Du kan nu se utsidan genom den öppna porten."
            );


            // ==========================================
            // ASK IF THE PLAYER WANTS TO GO OUT
            // ==========================================

            Menu exitMenu = new Menu();

            int exitChoice = exitMenu.Ask(
                "Vad vill du göra?",
                [
                    "Gå ut genom porten",
                    "Stanna i kyrkan"
                ]
            );


            // Player stays inside
            if (exitChoice == 2)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Du bestämmer dig för att stanna kvar i kyrkan."
                );

                return;
            }


            // Player leaves the church
            if (exitChoice == 1)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Du går ut genom kyrkporten."
                );

                player.Teleport("Wedding");

                return;
            }
        }
    }
}