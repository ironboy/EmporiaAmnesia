class Foyer : Location
{
  private Cleaner _cleaner = new();
  private Friend _friend = new();
  private bool _Money = false;

  public Foyer()
  {
    Name = "Foaje";
    Description = "Där är en städare, hon kanske vet vad som hände igår?";
  }

  public override void Interact(Player player)
  {
    bool cleaner = true;
    bool friend = true;

    if (friend == true)
    {
      _friend.Interact(player);
      if (!_Money)
      {
        player.Backpack.Add(new Item("pengar", "25.000kr, najs..."));
        _Money = true;
      }
    }
    else
    {
      
    }

    if (cleaner == true)
    {
      _cleaner.Interact(player);
    }
    else
    {
      
    }

    
  }
}