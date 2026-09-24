class DryCleanerNPC : Npc
{
    private bool hasGivenCostume = false;
    private bool invitedToWedding = false;
    public DryCleanerNPC()
    {
        Name= "Kemtvättaren";
    }
    public override void Interact(Player player)
    {
        if (hasGivenCostume == false)
        {
            Console.WriteLine("Kemtvättaren: Har du ditt kvitto med dig?");
            if (player.Backpack.Has("kemtvättskvitto"))
            {
                Console.WriteLine("Kemtvättaren: Ah! Du har kvittot. Här är din kostym.");
                player.Backpack.Remove("kemtvättskvitto");
                player.Backpack.Add(new Item("kostym","Min bröllopskostym!"));
                
                hasGivenCostume = true;
                Console.WriteLine("Du känner igenom fickorna på kostymen... RINGEN ÄR BORTA!");
            }
            else
            {
                Console.WriteLine("Kemtvättaren:: Du måste har kemtvättskvitto med dig för att få din kostym");
                
            }
            
            
        }
        else if (hasGivenCostume==true && invitedToWedding==false)
            {
                Console.WriteLine("Du: Min ring måste har trillat ur nångonstans, den är inte i fikan.");
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