class Partner : Npc
{
    public Partner()
    {
        Name = "Partner";
    }

    public override void Interact(Player player)
    {
        // The partner reacts after the ex interrupts the wedding
        Console.WriteLine();
        Console.WriteLine("Partnern tittar chockat på exet.");
        Console.WriteLine();

        Console.WriteLine(
            "\"Vad pratar du om? Det där är inte sant!\""
        );

        Console.WriteLine();

        Console.WriteLine(
            "\"Vi kan bevisa att äktenskapet är avslutat.\""
        );
    }


    // This interaction is used when the player returns after the drama
    public void Interact(Player player, bool dramaHasStarted)
    {
        if (dramaHasStarted)
        {
            Console.WriteLine();
            Console.WriteLine("Partnern tittar på dig.");
            Console.WriteLine();

            Console.WriteLine(
                "\"Fick du tag på skilsmässobeviset?\""
            );

            Menu proofMenu = new Menu();

            int choice = proofMenu.Ask(
                "Vad svarar du?",
                ["Ja", "Nej"]
            );


            // The player says yes
            if (choice == 1)
            {
                if (player.Backpack.Has("skilsmässobevis"))
                {
                    Console.WriteLine();
                    Console.WriteLine("\"Perfekt! Visa det för prästen.\"");

                    Console.WriteLine();
                    Console.WriteLine(
                        "\"Då kan vi fortsätta vigseln.\""
                    );

                    return;
                }

                Console.WriteLine();
                Console.WriteLine(
                    "\"Men du har ju inte skilsmässobeviset med dig.\""
                );

                return;
            }


            // The player says no
            if (choice == 2)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "\"Okej. Vi kan inte fortsätta vigseln utan det.\""
                );

                return;
            }
        }
    }
}