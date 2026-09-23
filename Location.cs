class Location : IInteractable
{
  public string Name { get; protected set; } = "";
  public string Description { get; protected set; } = "";

  // Which exits the movement menu shows here, e.g. [Direction.North, Direction.East]
  public Direction[] Directions { get; protected set; } = [];

  // Items lying around here. "Undersök platsen" lists them,
  // "Ta ett föremål" moves one of them into the player's backpack
  public List<Item> Items { get; } = [];

  // What happens when the player chooses "Interagera" here.
  // Override this in your own location - this is where your puzzle lives.
  public virtual void Interact(Player player)
  {
    Console.WriteLine("Det finns inget att göra här.");
  }

}
