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
        if (Bribed)
        {
            Console.WriteLine("\"Jag har inte sett dig. Gå nu\"");
            return;
        }

        int choice = new Menu().Ask("Vad gör du här så sent på natten?", ["\"Jag vaknade här\"", "Du försöker att attackera vakten", "\"Ring polisen då, jag bryr mig inte\""]);

        if (choice == 1)
        {
            Console.WriteLine("\n==Vakten\nDu vet att polisen kommer bli kontaktad va? Om du inte kan hitta en annan lösning...");

            Menu bribeMenu = new Menu();
            int chosen = bribeMenu.Ask(
                "Om du har pengar skulle vi kunna prata om en lösning...",
                ["Ja", "Nej"]
            );
            if (chosen == 2 /*Nej*/)
            {
                Console.WriteLine("\"Jaså inte det...\"");
                CallPolice(player);
            }
            else /* Ja */
            {
                if (player.Backpack.Has("pengar"))
                {

                    player.Backpack.Remove("pengar");
                    Bribed = true;
                   GiveTaxiCard(player);
                    Console.WriteLine("Vakten stoppar på sig bunten. \"Vilket larm?\"");
                    GiveTaxiCard(player);
                }
                else
                {
                    Console.WriteLine("\"Du ljuger - jag har muddrat dig. Inga pengar!\"");
                    CallPolice(player);
                    return;
                }
            }

        }
        else if (choice == 2)
        {
            Console.WriteLine("Du försöker att attackera vakten, men du har ingen chans och han knockar dig\nGAME OVER");
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
        Console.WriteLine("\nGAME OVER. Bröllopet blir av utan dig");
        player.GameOver = true;
    }

    private void GiveTaxiCard(Player player)
    {
        if (gaveTaxiCard)
        {
            Console.WriteLine("Du har redan taxikortet. Taxistationen ligger österut");
            return;
        }
        Console.WriteLine("Han skjuter ett plastkort över bordet");
        Console.WriteLine("\"Ett taxikort från jobbet. Ingen kommer att sakna det\"");
        Console.WriteLine("\"Taxistationen ligger österut. Kom inte tillbaka\"");
        gaveTaxiCard = true;
        player.Backpack.Add(new Item("taxikort", "Ett taxikort från vaktens jobb"));
    }

}