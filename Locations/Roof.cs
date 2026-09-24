class Roof : Location
{
    public Roof()
    {
        //Set the location name and description
        Name = "Taket";
        Description = "Du står vid dörren till taket. Dörren är låst och kräver ett nyckelkort.";
        //Kepp the way back open, but lock they way to the parking deck
        Directions = [Direction.West];
    }
    public override void Interact(Player player)
    {
        //Check if the plyaer has the required keycard
        if (player.Backpack.Has("nyckelkort"))
        {
            Console.WriteLine("Du håller nyckelkortet mot läsaren. Dörren till taket låses upp.");
            //Restore all available driections after unlocking the door
            Directions = Map.DirectionsFor(this);

            Description = "Dörren till taket är upplåst. Österut ligger parkeringsdäcket.";
        }
        else
        {
            Console.WriteLine("Dörren är låst. Du behöver ett nyckelkort för att komma vidare.");
        }
    }

}