class Foyer : Location
{
  private Cleaner _cleaner = new();
  private Friend _friend = new();

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
      Items.Add(new Item("pengar", "25.000kr!!"));
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