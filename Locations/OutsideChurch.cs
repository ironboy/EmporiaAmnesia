class OutsideChurch : Location

{
    public OutsideChurch()
    {
        Name = "Bröllop";
 
        Description = @"
╔══════════════════════════════════════════════════════╗
║                  ✦  BRÖLLOPET  ✦                     ║
╠══════════════════════════════════════════════════════╣
║                                                      ║
║                         †                            ║
║                         │                            ║
║                        / \                           ║
║                       /   \                          ║
║                      /_____\                         ║
║                      |  ○  |                         ║
║                  ____|_____|____                     ║
║                 /               \                    ║
║                /       ___       \                   ║
║               /       /   \       \                  ║
║              /_______/_____\_______\                 ║
║              |  []      ○      []  |                 ║
║              |                     |                 ║
║              |  []           []    |                 ║
║              |        ___          |                 ║
║              |       /   \         |                 ║
║              |      /     \        |                 ║
║              |     |       |       |                 ║
║              |_____|_______|_______|                 ║
║                    /       \                         ║
║                   /         \                        ║
║                                                      ║
║         Du står framför den stora katedralen         ║
║       Bröllopsgäster står fortfarande utanför        ║
║                                                      ║
║        Någonstans där inne väntar din partner        ║
║                                                      ║
╚══════════════════════════════════════════════════════╝";
 
        // Go to taxistation or outsidehouse. Church is on teleport in a method
      Directions = [Direction.East];
    }
 
    public override void Interact(Player player)
    {
      Menu doorMenu = new Menu();
 
      int choice = doorMenu.Ask(
            "Vill du öppna kyrkporten?",
            ["Ja", "Nej"]
      );
 
      if (choice == 2)
      {
        Console.WriteLine();
        Console.WriteLine(
            "Du bestämmer dig för att inte öppna kyrkporten.\nPorten stängdes igen."
        );

        return;
      }
      else
      {
        Console.WriteLine("\nDu tar tag i den stora kyrkporten.\nPorten knarrar när den långsamt öppnas.\nDu kan nu se in i kyrkan.");
          
        Menu enterMenu = new Menu();
  
        int enterChoice = enterMenu.Ask(
          "Vad vill du göra?",
          [
              "Gå igenom porten",
              "Stanna utanför"
          ]
        );
  
        if (enterChoice == 2)
        {
          Console.WriteLine(
              "\nDu bestämmer dig för att stanna utanför.\nPorten stängdes igen."
          );

          return;
        }

        else
        {
          
          Console.WriteLine(
              "\nDu går igenom kyrkporten och in i kyrkan."
          );

          player.Teleport("Church");

          return;
        }
      }    
  }
}