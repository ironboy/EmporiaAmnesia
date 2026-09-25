class BackRoom : Location
{
public BackRoom()
  {
    Name = "Bakrummet";
    Description = "Jag har kommit in i det lilla rummet bakom kemtvätten. Det är saker överallt. En hög med kläder, en tvättkorg, en liten skål med mynt, knappar och andra småsaker. ";
    
    // Lägger till föremål som spelaren kan undersöka
    Items.Add(new Item("smutstvätt", "Kanske något som passar till kostymen?."));
    Items.Add(new Item("jordnötsringar", "Kan funka som vigselring i nödfall? ."));
  }

  public override void Interact(Player player)
    {
        
        bool foundRing = false;

        // Snurrar runt tills man hittar ringen eller ger upp (break).
        while (!foundRing) 
        {

        Console.Write("Var vill du leta? 1. Under klädhögen, 2. I tvättkorgen, 3. I skålen \n4. Strunta att leta efter vigselringen och ta en av jordnötsringarna i påsen på bordet istället ");
        string? chosenPlace = Console.ReadLine();

        // Fel ställe.
        if (chosenPlace == "1")
        {
            Console.WriteLine("Här finns ingenting. Bara kläder.");
            
        }
        // Fel ställe.
       else if (chosenPlace == "2")
        {
            Console.WriteLine("Här finns ingenting. Bara en massa smutsiga kläder.");
            
        }
        // Rätt ställe.
        else if (chosenPlace == "3")
        {
            Console.WriteLine(@"
  ___  
 /   \ 
|     |
 \___/ 
");
           
            Console.WriteLine("Åh en sån lättnad! Här är min ring!!");
            player.Backpack.Add(new Item("ring", "Vigselringen till bröllopet"));
            foundRing = true; // Detta gör att loopen avslutas.
        
        
        }

        // Spelaren ger upp och tar en jordnötsring.
        else if (chosenPlace == "4")
            {
                player.Backpack.Add(new Item("jordnötsring", "Ring som ring?"));
                Console.WriteLine("Hoppas den passar!");
                break; // "break" avbryter loopen direkt, även om foundRing är false.
            }
        }
    }
}       

    