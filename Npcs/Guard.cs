class Guard : Npc
{
    private bool bribed = false;

    public Guard()
    {
        Name = "Vakten";
    }

    public override void Interact(Player player)
    {
        if (bribed)
        {
            Console.WriteLine("\"Jag har inte sett dig. Gå nu.\"");
            return;
        }
        if (player.Backpack.Has("pengar"))
        {
            player.Backpack.Remove("pengar");
            bribed = true;
            Console.WriteLine("Vakten stoppar på sig bunten. \"Vilket larm?\"");
            return;
        }
        Console.WriteLine("\"Du sitter här tills polisen kommer.\"");
    }
}