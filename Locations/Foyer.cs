class Foyer : Location
{
  private Cleaner _cleaner = new();
  private Friend _friend = new();
  private bool _money = false;

  public Foyer()
  {
    Name = "Foajé";
    Description = "Jag kommer till en stor foajé.\nEn städerska går långsamt runt med sin städvagn och plockar undan skräp.\nNär hon får syn på mig så stannar hon upp och tittar på mig.\n\"Jasså, är du kvar här?\"";
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