class DryCleaner : Location
{
 public DryCleaner()
  {
    Name = "Kemtvätt";
    Description = "Jag är inne på kemtvätten. Det är lite skum belysning och jag ser någon fixa med någonting inne i hörnet. Jag visste inte att kemtvättare jobbar natt! ";
    Directions = [Direction.North, Direction.West];
    
    
  }


    private DryCleanerNPC _drycleanerNPC = new();
    public override void Interact(Player player)
    {
        _drycleanerNPC.Interact(player);
        
    }
    
}