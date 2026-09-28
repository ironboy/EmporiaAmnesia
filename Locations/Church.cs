// The church introduces the wedding scene. The altar contains the actual checks.
class Church : Location
{
    public Church()
    {
        Name = "Kyrkan";
        Description = "En vacker kyrka förberedd för ett bröllop. Längst fram finns altaret där vigseln ska äga rum.";
    }

    public override void Interact(Player player)
    {
        // This location presents the scene; it does not modify the player's items.
        Console.WriteLine("Du går in i kyrkan.");
        Console.WriteLine("Längre fram ser du altaret där prästen och partnern står.");
        Console.WriteLine("Exet sitter längre bak i kyrkan.");
        Console.WriteLine("Gå till altaret när du är redo för vigseln.");
    }
}