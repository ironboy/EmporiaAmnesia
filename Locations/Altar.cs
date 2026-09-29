// The altar coordinates the wedding scene and owns the NPCs involved in it.
class Altar : Location
{
    // These exact item names are used in the backpack.
    private const string CostumeItem = "kostym";
    private const string RingItem = "ring";
    private const string DivorcePapersItem = "skilsmässobevis";

    // The altar decides which NPC is interacted with and in what order.
    private Priest _priest = new();
    private Ex _ex = new();
    private Partner _partner = new();

    // Checks if the ex has already interrupted the wedding.
    private bool _dramaHasStarted = false;

    // Counts how many times the player tries without a costume.
    private int _missingCostumeAttempts = 0;

    // Counts how many times the player tries without a ring.
    private int _missingRingAttempts = 0;


    public Altar()
    {
        Name = "Altaret";

        Description =
            "Du står framme vid altaret. Prästen och partnern väntar på dig, " +
            "medan exet sitter längre bak i kyrkan.";
    }


    public override void Interact(Player player)
    {
        // Check what items the player has.
        bool hasCostume = player.Backpack.Has(CostumeItem);
        bool hasRing = player.Backpack.Has(RingItem);


        // ==========================================
        // MISSING BOTH COSTUME AND RING
        // ==========================================

        if (!hasCostume && !hasRing)
        {
            _missingCostumeAttempts++;
            _missingRingAttempts++;

            Console.WriteLine();
            Console.WriteLine("Prästen tittar på dig från topp till tå.");


            // First attempt
            if (_missingCostumeAttempts == 1)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "\"Du har ju dina vanliga kläder på dig.\""
                );

                Console.WriteLine(
                    "\"Och du verkar inte ha någon ring heller.\""
                );

                Console.WriteLine();
                Console.WriteLine(
                    "\"Du behöver både kostym och ring innan vi kan börja.\""
                );

                return;
            }


            // Second attempt
            if (_missingCostumeAttempts == 2)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "\"Du är fortfarande inte ombytt...\""
                );

                Console.WriteLine(
                    "\"Och ringen saknas fortfarande.\""
                );

                Console.WriteLine();
                Console.WriteLine(
                    "\"Gå och hämta dina saker först.\""
                );

                return;
            }


            // Third attempt and every attempt after that
            Console.WriteLine();
            Console.WriteLine(
                "\"Men snälla... du har fortfarande dina vanliga kläder på dig!\""
            );

            Console.WriteLine(
                "\"Vad har du gjort, sovit på taket eller?\""
            );

            Console.WriteLine();

            Console.WriteLine(
                "\"Och var är ringen?!\""
            );

            Console.WriteLine();

            Console.WriteLine(
                "\"Hämta kostymen och ringen!\""
            );

            return;
        }


        // ==========================================
        // MISSING COSTUME
        // ==========================================

        if (!hasCostume)
        {
            _missingCostumeAttempts++;

            Console.WriteLine();
            Console.WriteLine("Prästen tittar på dig från topp till tå.");


            // First attempt
            if (_missingCostumeAttempts == 1)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "\"Du har ju dina vanliga kläder på dig.\""
                );

                Console.WriteLine(
                    "\"Du behöver hitta din kostym innan vi kan börja.\""
                );

                return;
            }


            // Second attempt
            if (_missingCostumeAttempts == 2)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "\"Du är fortfarande inte ombytt...\""
                );

                Console.WriteLine(
                    "\"Gå och hämta kostymen först.\""
                );

                return;
            }


            // Third attempt and every attempt after that
            Console.WriteLine();
            Console.WriteLine(
                "\"Men snälla... du har fortfarande dina vanliga kläder på dig!\""
            );

            Console.WriteLine(
                "\"Vad har du gjort, sovit på taket eller?\""
            );

            Console.WriteLine();

            Console.WriteLine(
                "\"Hämta kostymen!\""
            );

            return;
        }


        // ==========================================
        // MISSING RING
        // ==========================================

        if (!hasRing)
        {
            _missingRingAttempts++;

            Console.WriteLine();
            Console.WriteLine("Prästen tittar på dina händer.");


            // First attempt
            if (_missingRingAttempts == 1)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "\"Du har kostymen på dig, det är bra...\""
                );

                Console.WriteLine(
                    "\"Men var är ringen?\""
                );

                Console.WriteLine();
                Console.WriteLine(
                    "\"Du måste hitta ringen innan vigseln kan börja.\""
                );

                return;
            }


            // Second attempt
            if (_missingRingAttempts == 2)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "\"Ingen ring den här gången heller?\""
                );

                Console.WriteLine();
                Console.WriteLine(
                    "\"Jag hoppas verkligen att du vet var du har lagt den.\""
                );

                return;
            }


            // Third attempt and every attempt after that
            Console.WriteLine();
            Console.WriteLine(
                "\"Du är fortfarande här... och fortfarande utan ring?\""
            );

            Console.WriteLine();

            Console.WriteLine(
                "\"Jag vet inte hur många gånger jag behöver säga det här.\""
            );

            Console.WriteLine(
                "\"Hämta ringen!\""
            );

            return;
        }


        // ==========================================
        // RETURN AFTER THE EX INTERRUPTED
        // ==========================================

        if (_dramaHasStarted)
        {
            Console.WriteLine();
            Console.WriteLine(
                "Du kommer tillbaka till altaret."
            );


            // The partner talks to the player.
            _partner.Interact(player, true);


            // Check if the player has the divorce papers.
            if (!player.Backpack.Has(DivorcePapersItem))
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Du måste hitta skilsmässobeviset innan vigseln kan fortsätta."
                );

                return;
            }


            Console.WriteLine();
            Console.WriteLine(
                "Du tar fram skilsmässobeviset och visar det för prästen."
            );

            Console.WriteLine();
            Console.WriteLine(
                "Prästen läser igenom skilsmässobeviset."
            );

            Console.WriteLine();

            Console.WriteLine(
                "\"Allt verkar vara i sin ordning.\""
            );

            Console.WriteLine(
                "\"Då kan vi återuppta vigseln.\""
            );


            // Continue the wedding.
            _priest.ContinueWedding(player);

            return;
        }


        // ==========================================
        // START THE WEDDING
        // ==========================================

        Console.WriteLine();
        Console.WriteLine(
            "Du ställer dig bredvid din partner framför prästen."
        );

        Console.WriteLine(
            "Kyrkan blir tyst och gästerna vänder sig mot er."
        );

        Console.WriteLine();


        // The priest starts the wedding.
        _priest.Interact(player);


        // ==========================================
        // PLAYER SAID NO
        // ==========================================

        // Stop the wedding if the player says no.
        if (!_priest.PlayerSaidYes)
        {
            Console.WriteLine();
            Console.WriteLine(
                "Vigseln avbryts."
            );

            return;
        }


        // ==========================================
        // SILENCE BEFORE THE EX INTERRUPTS
        // ==========================================

        Console.WriteLine();
        Console.WriteLine(
            "Kyrkan blir helt tyst..."
        );

        Console.WriteLine();

        Console.WriteLine(
            "Tryck ENTER för att fortsätta."
        );

        // Wait for the player to press Enter.
        Console.ReadLine();


        // ==========================================
        // THE EX INTERRUPTS
        // ==========================================

        _ex.Interact(player);


        // ==========================================
        // THE PARTNER RESPONDS
        // ==========================================

        _partner.Interact(player);


        // ==========================================
        // THE PRIEST STOPS THE WEDDING
        // ==========================================

        Console.WriteLine();
        Console.WriteLine(
            "Prästen höjer handen för att få alla att vara tysta."
        );

        Console.WriteLine();

        Console.WriteLine(
            "\"Jag kan inte fortsätta vigseln förrän vi vet sanningen.\""
        );

        Console.WriteLine();

        Console.WriteLine(
            "\"Ni måste hitta skilsmässobeviset.\""
        );


        // Remember that the wedding has been interrupted.
        _dramaHasStarted = true;
    }
}
