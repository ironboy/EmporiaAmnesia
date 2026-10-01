class Foyer : Location
{
  private Cleaner _cleaner = new();

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
    _cleaner.Interact(player);
  }
}