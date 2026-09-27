class TaxiStation : Location
{



    private TaxiDriver _taxiDriver = new();

// contructor for taxi station with ascii art and text
    public TaxiStation()
    {
        Name = "Taxi Station";
        Description = @"
╔════════════════════════════════════════════════════╗
║               TAXISTATION ÖPPET 24/7               ║
╠════════════════════════════════════════════════════╣
║                                                    ║
║                    __________                      ║
║                   /          \                     ║
║          ________/    TAXI    \_______             ║
║         /                            \             ║
║        |    ______________________    |            ║
║        |   |                      |   |            ║
║        |   |        TAXI          |   |            ║
║        |___|______________________|___|            ║
║          O                            O            ║
║                                                    ║
║              TAXI     TAXI     TAXI                ║
║                                                    ║
║        Du kommer fram till en taxi station.        ║      
║        Tur för dig så är det öppet 24/7.           ║
║        En taxichaufför verkar va redo för dig.     ║
║                                                    ║
║                                                    ║
╚════════════════════════════════════════════════════╝";

       //Directions = [Direction.West];
       Directions = [Direction.None];
    }
    

// Interact with the taxi station and since you cant go to SecurityOffice as you cannot leave that location. There is instead a player teleport to parkingdeck
  public override void Interact(Player player)
  {
    Menu stationMenu = new Menu();
    int val = stationMenu.Ask("Vad vill du göra på taxi stationen?", ["Prata med taxichauffören", "Gå tillbaka till parkeingsplatsen"]);

    if (val == 2)
    {
        Console.WriteLine("Du bestämmer dig för att gå tillbaka till parkeringsplatsen.");
        player.Teleport("ParkingDeck");
        return;
    }

    _taxiDriver.Interact(player);
    if (_taxiDriver.Taxiresa)
    {
        Console.WriteLine("Du sätter dig i backsätet och taxin börjar att gasa iväg genom staden.");
        _taxiDriver.Taxiresa = false;
        player.Teleport("Wedding");
    }
  }
}

//Old method for interacting with taxi driver now changed so what we can teleport. ""public override void Interact(Player player)
//{

 //       _taxiDriver.Interact(player);

   //     if (_taxiDriver.Taxiresa)

     //   {

       //     Console.WriteLine("Du sätter dig i baksätet. Taxin börjar att gasa iväg genom staden");

        //    player.Teleport("Wedding");

        //}

    //} 