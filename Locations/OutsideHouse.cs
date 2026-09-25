class OutsideHouse : Location
{
    public OutsideHouse()
    {
        Name = "Utanför huset";
        Description = "Du står utanför huset. Dörren är låst och du kan inte komma in.";


        Items.Add(new Item("Nyckel", "En liten nyckel som ligger på marken. Den ser ut att passa i dörren."));

    }

    public override void Interact(Player player)
    {
        if (player.Backpack.Has("Nyckel"))
        {
            Console.WriteLine("Du använder nyckeln för att låsa upp dörren. Du kan nu gå in i huset.");
        }
        else
        {
            Console.WriteLine("Dörren är låst. Du behöver en nyckel för att komma in.");
        }
    }

}