// The altar coordinates the wedding scene and owns the NPCs involved in it.
class Altar : Location
{
    // These exact item names are the contract with the groups that provide the items.
    private const string CostumeItem = "kostym";
    private const string RingItem = "ring";

    // The altar decides which NPC is interacted with and in what order.
    private Priest _priest = new();
    private Ex _ex = new();
    private Partner _partner = new();

    // Checking if the drama with the ex has started or not
    private bool _dramaHasStarted = false;

    public Altar()
    {
        Name = "Altaret";
        Description = "Du står framme vid altaret. Prästen och partnern väntar på dig, medan exet sitter längre bak i kyrkan.";
    }

    public override void Interact(Player player)
    {
        // Read the backpack once so every prerequisite check uses the same state.
        bool hasCostume = player.Backpack.Has(CostumeItem);
        bool hasRing = player.Backpack.Has(RingItem);

        if (!hasCostume)
        {
            Console.WriteLine("Prästen tittar på dig.");
            Console.WriteLine("\"Du saknar en kostym.\"");
            return;
        }

        if (!hasRing)
        {
            Console.WriteLine("Prästen tittar på dig.");
            Console.WriteLine("\"Du saknar en ring.\"");
            return;
        }

        // Checking if the drama has happened
        if (_dramaHasStarted)
        {
            // If the drama has happened 
            _partner.Interact(player, true);
        }
        else
        {
            // Each NPC owns its own dialogue; the altar only controls the sequence.
            _priest.Interact(player);
            _ex.Interact(player);
            _partner.Interact(player);

            _dramaHasStarted = true;
        }
    }
}