class SecurityOffice : Location
{
    // A common convention when naming private fields
    // is naming with and underscore followed but a small letter
    // This makes simple to distinguish from public fields that 
    // you start a capital
    private Guard _guard = new();
    public SecurityOffice()
    {
        Name = "Säkerhetsvakternas kontor";
        Description = "Du är på säkersvakternas kontor";
    }

    public override void Interact(Player player)
    {
        // When the player asks to interact with the location
        // then the room can start an interaction with an NPC
        _guard.Interact(player);
    }
}