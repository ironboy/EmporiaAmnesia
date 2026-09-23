// A person the player can talk to. Works exactly like Location:
// set Name in the constructor and override Interact with what happens.
// A location owns its npcs and calls npc.Interact(player) from its own Interact.
class Npc : IInteractable
{
  public string Name { get; protected set; } = "";

  public virtual void Interact(Player player)
  {
    Console.WriteLine($"{Name} har inget att säga.");
  }
}
