class Foyer : Location
{
  private Cleaner _cleaner = new();
  private Friend _friend = new();
  private bool _money = false;

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
      if (!_money)
      {
        player.Backpack.Add(new Item("pengar", "25.000kr, najs..."));
        _money = true;
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