class DryCleaner : Location
{
 public DryCleaner()
  {
    Name = "Kemtvätt";
    Description = "Jag står inne på kemtvätten. Bakom disken står en anställd och fixar med nytvättad tvätt. Han jobbar tydligen natt. Skönt, då kan jag få min kostym!";
    
    // Spelaren ska bjuda in Kemtvättaren till sin brölopp
    // Kemtvättaren låter han tar ringen.
  }


    private DryCleanerNPC _drycleanerNPC = new();
    public override void Interact(Player player)
    {
        _drycleanerNPC.Interact(player);
        
    }
    
}