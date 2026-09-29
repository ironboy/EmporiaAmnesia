class Foyer : Location
{
  private Cleaner _cleaner = new();
  private Friend _friend = new();
  private bool _money = false;
  bool cleaner = true;
  bool friend = false;
  int cleanerCount = 0;

  public Foyer()
  {
    Name = "Foajé";
    Description = $"{DrawFoyer()}En städerska går långsamt runt med sin städvagn och plockar undan skräp.\nNär hon får syn på mig så stannar hon upp och tittar på mig.\n\"Jasså, är du kvar här?\"";

  }

  public static string DrawFoyer()
  {
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    string art = @"
                                   ▲
                                  NORR
                           Trappa till taket
              ╔═════════════════╗      ╔═════════════════╗
              ║  [====]         ║      ║         [====]  ║
              ║                                          ║
              ║          O                               ║
    VÄST      ║  ____   /|\                 o            ║      ÖST
 Städförråd ◄──  |____|_/ \                /|\            ──► Rulltrappa
              ║   o  o   städerska         / \           ║
              ║                            DU            ║
              ║                                          ║
              ║  [_]            ║      ║           [_]   ║
              ╚═════════════════╝      ╚═════════════════╝
                              Toalettbåset
                                 SÖDER
                                   ▼
";
return art;
  }


  public override void Interact(Player player)
  {
    if (cleanerCount >= 1)
    {
      cleaner = false;
      friend = true;
    }
    if (friend == true)
    {
      _friend.Interact(player);
      if (!_money)
      {
        player.Backpack.Add(new Item("pengar", "25.000kr, najs..."));
        _money = true;
      }
    }

    if (cleaner == true)
    {
      _cleaner.Interact(player);
      cleanerCount++;
    }

  }
}