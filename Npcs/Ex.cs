class Ex : Npc
{
    public Ex()
    {
        Name = "Exet";
    }
    public override void Interact(Player player)
    {
        Console.WriteLine("Exet skriker: " 
        + "\nBrudgummen är gift med mig!");
    }
}