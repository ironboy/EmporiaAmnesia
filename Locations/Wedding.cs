class Wedding : Location
{
    private Priest _priest = new();
    private Ex _ex = new();
    private Partner _partner = new();

    public Wedding()
    {
        Name = "Kyrkan";
        Description= "Du är på ditt bröllop i kyrkan.";
        // The player cannot leave the room before interacting with the priest
        Directions = [Direction.None];
    }

    public override void Interact(Player player)
    {
        // The first interaction with the priest before the drama
        if (!_priest.HasProof)
        {
            _priest.Interact(player);

            // The player has interacted with the priest and can now move to another location
            if (_priest.HasProof)
            {
                Directions = Map.DirectionsFor(this);
            }
            return;
        }

        // If the Ex has interveined, you can now communicate with all of them
        Menu npcMenu = new();
        int chosen = npcMenu.Ask(
            "Vem vill du prata med?",
            ["Prata med prästen", "Prata med exet", "Prata med partnern"]
        );

        if(chosen == 1)
        {
            _priest.Interact(player); 
        }
        else if (chosen == 2)
        {
            _ex.Interact(player);
        }else if (chosen == 3)      
        {
            _partner.Interact(player);
        }
    }
}
