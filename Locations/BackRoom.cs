class BackRoom : Location
{
public BackRoom()
  {
    Name = "Bakrummet";
    Description = "Jag har kommit in i det lilla rummet bakom kemtvätten. Det är saker överallt. En hög med kläder, en tvättkorg, en liten skål med mynt, knappar och andra småsaker. ";
    
  }

  public override void Interact(Player player)
    {
        
        bool foundRing = false;

        while (!foundRing) 
        {

        Console.Write("Var vill du leta? 1. Under klädhögen, 2. I tvättkorgen, 3. I skålen: ");
        string? chosenPlace = Console.ReadLine();

        if (chosenPlace == "1")
        {
            Console.WriteLine("Här finns ingenting. Bara kläder.");
            
        }
       else if (chosenPlace == "2")
        {
            Console.WriteLine("Här finns ingenting. Bara en massa smutsiga kläder.");
            
        }
        else if (chosenPlace == "3")
        {
            Console.WriteLine("Åh en sån lättnad! Här är min ring!!");
            player.Backpack.Add(new Item("Ring", "Vigselringen till bröllopet"));
            foundRing = true;
        
        {
        }
        }
        }
    }
}       

    