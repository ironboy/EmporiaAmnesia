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
    player.Backpack.Add(new Item("kemtvättskvitto", "Kemtvättskvitto"));

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
                Console.WriteLine("Min ring måste ha trillat ur nångonstans, den är inte i fickan. (Tryck på tangent för att fortsätta)");
                Console.ReadKey();
                Console.WriteLine("Kemtvättaren: Det kan vara så att den trillade ur under tvätten i Bakrummet.");
                Console.ReadKey();
                Console.WriteLine("Kan jag gå in och leta efter den?");
                Console.ReadKey();
                Console.WriteLine("Kemtvättaren: Absolut inte!!");
                Console.ReadKey();

                bool convincedHim = false;

                 while (!convincedHim)  //Snurrar tills man hittat sätt att få honom att släppa en in i bakrummet
                 {

                Console.Write("Vad vill du göra för att få honom att ändra sig? 1. Erbjuda dig att ta hans nästa nattpass eller 2. Bjuda honom till bröllopet? ");
                string? answer = Console.ReadLine();

                 if (answer == "1") //Fel svar
        {
             Console.WriteLine("Kom igen! Jag tar ditt nästa nattpass om jag får gå in!!");
             Console.ReadKey();
            Console.WriteLine("Kemtvättaren: Skulle inte tro det! Du ser inte ut att kunna klara mina avancerade arbetsuppgifter");
            
            
        }
                if (answer == "2") //Rätt svar som leder till att man blir insläppt
                {

                Console.WriteLine("Du: Snälla! Jag bjuder in dig till bröllopet, fri bar");
                Console.ReadKey();
                Console.WriteLine("Kemtvättaren: ...Okej då. Gå in snabbt innan jag ångrar mig.");
                convincedHim = true;

                }
            }
                
                invitedToWedding = true;          
                player.Teleport("BackRoom");  //Man förflyttas till bakrummet
                
            }

    }

    
}