class TaxiStation : Location
{



    private TaxiDriver _taxiDriver = new();

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
        Directions = [Direction.None];
    }
    
    public override void Interact(Player player)
    {
        _taxiDriver.Interact(player);

        if (_taxiDriver.Taxiresa)
        {
            Console.WriteLine("Du sätter dig i baksätet. Taxin börjar att gasar iväg genom staden");
            player.Teleport("Wedding");
        }
    }



}