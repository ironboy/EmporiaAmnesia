class Backpack
{
  public List<Item> Items { get; } = [];

  public void Add(Item item)
  {
    Items.Add(item);
    Console.WriteLine($"Du lägger {item.Name} i ryggsäcken.");
  }

  // Does the player carry an item with exactly this name? Spelling matters!
  public bool Has(string name)
  {
    foreach (Item item in Items)
    {
      if (item.Name == name)
      {
        return true;
      }
    }
    return false;
  }

  // Take an item out of the backpack (for example when paying or giving it away).
  // Returns the item, or null if the player did not have it.
  public Item? Remove(string name)
  {
    foreach (Item item in Items)
    {
      if (item.Name == name)
      {
        Items.Remove(item);
        return item;
      }
    }
    return null;
  }

  public void Print()
  {
    Console.WriteLine("\n== Ryggsäcken");
    if (Items.Count == 0)
    {
      Console.WriteLine("Den är tom.");
      return;
    }
    foreach (Item item in Items)
    {
      Console.WriteLine($"- {item}"); // uses Item.ToString()
    }
  }
}
