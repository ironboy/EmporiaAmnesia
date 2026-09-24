class DryCleaner : Location
{
 public DryCleaner()
  {
    Name = "Kemtvätt";
    Description = "Jag står inne på kemtvätten. I handen har jag kvittot för att hämta ut min kostym";
    //Ska spelaren interagera med den anställde i kemtvätten för att få sin kostym, eller sker det direkt i Description?
    // Spelaren ska bjuda in Kemtvättaren till sin brölopp
    // Kemtvättaren låter han tar ringen.
  }

//Sker det någon Interact här med rummet, eller bara med personalen i klassen npcs DryCleaner?
    private DryCleanerNPC _drycleanerNPC = new();
    public override void Interact(Player player)
    {
        _drycleanerNPC.Interact(player);
        
    }
    
}