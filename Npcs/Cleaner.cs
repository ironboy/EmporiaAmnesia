class Cleaner : Npc
{
  private bool _cleanerTalk = false;
  public bool FindFriend = false;

  public Cleaner()
  {
    Name = "Städaren";
  }

  public override void Interact(Player player)
  {
    if (FindFriend)
    {
      Console.WriteLine("\n\"Jag har redan sagt allt jag vet.\"");
      return;
    }

    if (!_cleanerTalk)
    {
      Console.WriteLine("\n\"Jag såg att du kom in med en kompis här igårkväll.\"");
      Console.WriteLine("\n\"Ni verkade ha en viktig tillställning som väntade er.\"");
      _cleanerTalk = true;
      return;
    }

    Console.WriteLine("\n\"Jag har inget minne från igår, har du sett honom?\"");
    Console.WriteLine("\"Han ligger där borta i hörnet utslagen.\"");
    FindFriend = true;
  }
}
