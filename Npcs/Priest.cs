class Priest : Npc
{
    public Priest()
    {
        Name = "Prästen";
    }

    public override void Interact(Player player)
    {
        Console.WriteLine("Prästen tittar på brudparet.");
        Console.WriteLine("\"Finns det någon som har något att invända?\"");
    }
}