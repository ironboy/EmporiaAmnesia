class Ex : Npc
{
    public Ex()
    {
        Name = "Exet";
    }

    public override void Interact(Player player)
    {
        Console.WriteLine();
        Console.WriteLine(
            "Plötsligt hörs en röst längst bak i kyrkan."
        );

        Console.WriteLine();
        Console.WriteLine(
            "\"JAG HAR NÅGOT ATT INVÄNDA!\""
        );

        Console.WriteLine();
        Console.WriteLine(
            "Exet reser sig upp."
        );

        Console.WriteLine();
        Console.WriteLine(
            "\"Ni kan inte gifta er! Vi är redan gifta!\""
        );
    }
}