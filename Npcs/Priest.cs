class Priest : Npc
{
    public bool HasProof = false;
    public Priest()
    {
        Name = "Prästen";
    }

    public override void Interact(Player player)
    {
        // When you don't have the divorce papers yet
        if (HasProof)
        {
            Console.WriteLine("Jag behöver skilsmässobeviset innan jag kan viga er.");
            return;
        }

        // Creating temporary ring and suit items
        player.Backpack.Add(new Item("ring", "Ringen i väskan"));
        player.Backpack.Add(new Item("kostym", "Kostymen från kemtvätten."));

        // Checking if the player meets all the requirements (has the ring and the suit)
        if (!player.Backpack.Has("ring") || !player.Backpack.Has("kostym"))
        {
            Console.WriteLine("Du kan inte gifta dig såhär. Kom tillbaka med en ring och en kostym på dig.");
            return;
        }

        Console.WriteLine("--- VIGSELCEREMONIN STARTAR ---");
        Console.WriteLine("Du står vid altaret bredvid din partner."
         + "\nPrästen tittar ut över församlingen, viker ihop sitt häfte och frågar:\n"
         + "Finns det någon i denna församling som har något att invända mot detta äktenskap?");
        Console.WriteLine("\n(Tryck på ENTER för att fortsätta...)");
        Console.ReadLine();
        Console.WriteLine("Du hör någon skrika: " + "\nJAG INVÄNDER! Stoppa bröllopet, vi två är redan gifta!" +
        "\nDu vänder dig om och ser att det är din EX...");

        Menu weddingMenu = new();
        int chosen = weddingMenu.Ask(
            "Vad är ditt val?",
            ["Du erbjuder dig att hämta skilsmässobeviset.", "Du erkänner att påståendet stämmer."]
        );

        if (chosen == 1)
        {
            Console.WriteLine("Du säger:" + "\nDet är inte sant. Jag har skilsmässobeviset, låt mig gå och hämta det.");
            HasProof = true;
        }
        else
        {
            Console.WriteLine("Du står helt lamslagen och tyst och säger slutligen:" + "\nHon har rätt. Vi är fortfarande gifta...");
            player.GameOver = true;
        }
    }
}