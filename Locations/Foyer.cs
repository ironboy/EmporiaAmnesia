class Foyer : Location
{
  private Cleaner _cleaner = new();

  public Foyer()
  {
    Name = "Foaje";
    Description = "Där är en städare, hon kanske vet vad som hände igår?";
  }

  public override void Interact(Player player)
  {
    _cleaner.Interact(player);
  }
}