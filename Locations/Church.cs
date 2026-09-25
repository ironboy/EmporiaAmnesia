class Church : Location
{
    public Church()
    {
        Name = "Kyrkan";
        Description = "En vacker kyrka där ett bröllop ska äga rum.";
    }

    public override void Interact(Player player)
    {
        Console.WriteLine("Du går in i kyrkan.");
        Console.WriteLine("Du ser altaret längre fram.");
        Console.WriteLine("Prästen och partnern står vid altaret.");
        Console.WriteLine("Exet sitter längre bak i kyrkan.");
    }
}