// A contract: anything the player can "Interagera" with promises to have
// an Interact method. Location and Npc are unrelated classes, but both
// implement this interface, so code can treat them the same way.
interface IInteractable
{
  void Interact(Player player);
}
