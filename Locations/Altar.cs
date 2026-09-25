class Altar : Location
{
    private Priest _priest = new();
    private Ex _ex = new();
    private Partner _partner = new();

    public Altar()
    {
        Name = "Altaret";
        Description = "Du står framme vid altaret.";
    }

    public override void Interact(Player player)
    {

        if (!player.Backpack.Has("kostym") && !player.Backpack.Has("ring"))
        {
            Console.WriteLine("Prästen tittar på dig.");
            Console.WriteLine("\"Du saknar både kostym och ring.\"");
            return;
        }

        if (!player.Backpack.Has("kostym"))
        {
            Console.WriteLine("Prästen tittar på dig.");
            Console.WriteLine("\"Du saknar en kostym.\"");
            return;
        }

        if (!player.Backpack.Has("ring"))
        {
            Console.WriteLine("Prästen tittar på dig.");
            Console.WriteLine("\"Du saknar en ring.\"");
            return;
        }

        _priest.Interact(player);
        _ex.Interact(player);
        _partner.Interact(player);

    }
}