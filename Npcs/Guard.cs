class Guard : Npc
{
    public bool Bribed = false;

    public Guard()
    {
        Name = "Vakten";
    }

    public override void Interact(Player player)
    {
        Console.WriteLine("\n==Vakten\nVad gör du här så sent på natten?");



        List<string> GuardConversation = [
            "1. Jag vaknade här",
            "2. Du försöker att attackera vakten",
            "3. Jag hittar inte ut..."
        ];

        foreach (string gaurdchoice in GuardConversation)
        {
            Console.WriteLine(gaurdchoice);
        }
        Console.WriteLine("\nVad vill du göra? ");
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
                    Console.WriteLine("Vakten stoppar på sig bunten. \"Vilket larm?\"");
                }
                else
                {
                    Console.WriteLine("\"Du ljuger - jag har muddrat dig. Inga pengar!");
                    Console.WriteLine("\"Du sitter här tills polisen kommer.\"");
                    player.GameOver = true;
                }
            }

        }
        /*
                else if (choice == 2)
                {
                    Console.WriteLine("Du försöker springa iväg, men vakten hinner ikapp");
                    player.GameOver = true;
                }

                else if (choice == 3)
                {

                }
        */
    }
}