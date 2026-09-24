class Partner : Npc
{
    public Partner()
    {
        Name = "Partner";
    }
    public override void Interact(Player player)
    {
        Console.WriteLine("Din partner säger gråtandes: " 
        + "\nSnälla skynda och hitta skilsmässobeviset! Låt henne inte förstöra vår dag!");
    }
}