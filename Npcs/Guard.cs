class Guard : Npc
{
    public bool Bribed = false;
    public bool gaveTaxiCard = false;

    public Guard()
    {
        Name = "Vakten";
    }

    public override void Interact(Player player)
    {
        Console.WriteLine("\n==Vakten\nVad gör du här så sent på natten?");



        List<string> GuardConversation = [
            "1. \"Jag vaknade här\"",
            "2. Du försöker att attackera vakten",
            "3. \"Ring polisen då, jag bryr mig inte\""
        ];

        foreach (string gaurdchoice in GuardConversation)
        {
            Console.WriteLine(gaurdchoice);
        }
        Console.WriteLine("\nGör ett val: ? ");
        int choice = int.Parse(Console.ReadLine()!);

        if (choice == 1)
        {
            Console.WriteLine("\n==Vakten\nDu vet att polisen kommer bli kontaktad va? Om du inte kan hitta en annan lösning...");

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
                    GiveTaxiCard(player);
                    Console.WriteLine("Vakten stoppar på sig bunten. \"Vilket larm?\"");
                }
                else
                {
                    Console.WriteLine("\"Du ljuger - jag har muddrat dig. Inga pengar!");
                    Console.WriteLine("\"Du sitter här tills polisen kommer.\"");
                    CallPolice(player);
                    return;
                }
            }

        }
        else if (choice == 2)
        {
            Console.WriteLine("Du försöker att attackera vakten, men du har ingen chans och han knockar dig");
            player.GameOver = true;
        }
        else if (choice == 3)
        {
            Console.WriteLine("Som du vill");
            CallPolice(player);
            return;
        }
    }

    private void CallPolice(Player player)
    {
        Console.WriteLine("Vakten lyfter telefonen och ringer polisen");
        Console.WriteLine("\"Du stannar här tills de kommer\"");
        Console.WriteLine("\nGAME OVER. Bröloppet blir av utan dig");
        player.GameOver = true;
    }

}