class Item
{
  public string Name { get; protected set; } = "";
  public string Description { get; protected set; } = "";

  // new Item("kemtvättskvitto", "Ett skrynkligt kvitto från Emporia Kemtvätt.")
  public Item(string name, string description = "")
  {
    Name = name;
    Description = description;
  }

  // Every object has a ToString(). Overriding it decides what
  // Console.WriteLine(item) and $"{item}" print.
  public override string ToString()
  {
    return Description == "" ? Name : $"{Name}: {Description}";
  }
}
