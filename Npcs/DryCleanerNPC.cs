class DryCleanerNPC : Npc
{
    // Minne för att hålla koll på var vi är i berättelsen.
    private bool hasGivenCostume = false;
    private bool invitedToWedding = false;
    public DryCleanerNPC()
    {
        Name= "Kemtvättaren";
    }

    
    public override void Interact(Player player)
    {
        // Kvitto har lagts tillfälligt i ryggsäcken för att kunna testa. Ska egentligen hittas av grupp 1
      if (!player.Backpack.Has("kemtvättskvitto"))
{
    player.Backpack.Add(new Item("kemtvättskvitto", "Kemtvättskvitto"));
}
       // Steg 1: Om spelaren inte har fått kostymen än.
        if (hasGivenCostume == false)
        {
            Console.Write("Kemtvättaren: Har du ditt kvitto med dig? Ja / Nej: ");
        string? answer = Console.ReadLine();

        // Svarar Ja och har kvittot -> Får kostymen.
        if (answer == "Ja" && player.Backpack.Has("kemtvättskvitto"))
        {
             Console.WriteLine("Kemtvättaren: Ah! Du har kvittot. Här är din kostym.");
                player.Backpack.Remove("kemtvättskvitto");
                player.Backpack.Add(new Item("kostym","Min bröllopskostym!"));
                
                hasGivenCostume = true; // Nu är kostymen utdelad.
                Console.WriteLine("Du känner igenom fickorna på kostymen... RINGEN ÄR BORTA!");
            
        }
        // Svarar Nej och saknar kvittot.
       else if (answer == "Nej" && !player.Backpack.Has("kemtvättskvitto"))
        {
            Console.WriteLine("Du måste ha kemtvättskvitto med dig för att få din kostym");
            
        }
        // Svarar Nej men kvittot ligger faktiskt i väskan.
        else if (answer == "Nej" & player.Backpack.Has("kemtvättskvitto"))
            {
               Console.WriteLine("Har du kollat i väskan?");
            }

        // Svarar Ja men har inget kvitto (ljuger).
           else if (answer == "Ja" && !player.Backpack.Has("kemtvättskvitto"))
            {
                Console.WriteLine("Du säger att du har det men jag ser inget kvitto! Jag kan inte ge dig någon kostym");
                
            }
            
            
        }
        // Steg 2: Spelaren har kostymen, upptäcker att ringen är borta och mutar kemtvättaren.
        else if (hasGivenCostume==true && invitedToWedding==false)
            {
                Console.WriteLine("Du: Min ring måste ha trillat ur nångonstans, den är inte i fickan.");
                Console.WriteLine("Kemtvättaren: Det kan vara så att den trillade ur under tvätten i Bakrummet.");
                Console.WriteLine("Du: Kan jag gå in och leta efter den?");
                Console.WriteLine("Kemtvättaren: Absolut inte!!");
                Console.WriteLine("Du: Snälla! Jag bjuder in dig till bröllopet, fri bar");
                Console.WriteLine("Kemtvättaren: ...Okej då. Gå in snabbt innan jag ångrar mig.");
                invitedToWedding = true;
                player.Teleport("BackRoom");
            }

    }

    
}