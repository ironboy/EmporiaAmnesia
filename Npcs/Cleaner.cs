class Cleaner : Npc
{
  public bool FindFriend = false;

  public Cleaner()
  {
    Name = "Städerskan";
  }

  public override void Interact(Player player)
  {
    if (FindFriend)
    {
      Console.WriteLine("\n\"Jag har redan sagt allt jag vet.\"");
      return;
    }
    {
      Console.WriteLine("\n\"Städerskan såg att du kom in med en kompis här igårkväll.\"");
      Console.WriteLine("\n\"Du har inget minne från igår och undrar om han också är här?\"");
      Console.WriteLine("\"Städerskan pekar mot städförrådet.\"");
      Console.WriteLine("\"Du går mot städförådet och öppnar nyfiket.\"");
      FindFriend = true;
  }
}
}

