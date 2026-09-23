class Location : IInteractable
{
  public string Name { get; protected set; } = "";
  public string Description { get; protected set; } = "";

  // Which exits the movement menu shows here. Map fills this in from the
  // neighbours in Map.Locations when the map is built, so you don't need to
  // set it. Assign it in your constructor only to override that,
  // e.g. Directions = [Direction.North]; to hide the other exits.
  public Direction[] Directions { get; set; } = [];

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
