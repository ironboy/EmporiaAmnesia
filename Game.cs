class Game
{

  bool isRunning = true;
  Map map = new();
  Player player;
  Menu menu = new();

  public Game()
  {
    // Field initializers can't reference other fields (CS0236), so wire up here
    // 2,0 temporarily replaced with 3,3 - UNDO LATER!
    player = new(2, 2, map); // starting position (row, col) = the toilet stall
  }


  public void Start()
  {
    Console.WriteLine("EMPORIA AMNESIA");
    while (isRunning)
    {
      PlayTurn();
    }
  }

  Location CurrentLocation() // location is an object of type Location (i e Toilet stall, Foyer, ...)
  {
    return map.GetLocation(player.Row, player.Col); // player.Row and player.Col is the player position - not player location...
  }

  void PlayTurn()
  {
    Location location = CurrentLocation();

    Console.WriteLine($"\n=== {location.Name} ===");
    Console.WriteLine(location.Description);

    int choice = menu.Ask("Vad vill du göra?", [
        "Förflytta dig",
        "Undersök platsen",
        "Ta ett föremål",
        "Interagera",
        "Titta i ryggsäcken",
        "Avsluta spelet"
    ]);

    switch (choice)
    {
      case 1:
        ChooseDirection();
        break;
      case 2:
        SearchLocation();
        break;
      case 3:
        TakeItem();
        break;
      case 4:
        Interact();
        break;
      case 5:
        player.Backpack.Print();
        break;
      case 6:
        isRunning = false; // stop game loop and exit
        Console.WriteLine("Spelet avslutas.");
        break;
    }
  }

  // Available directions are defined in each location
  void ChooseDirection()
  {
    Direction[] directions = CurrentLocation().Directions;
    if (directions.Length == 0)
    {
      Console.WriteLine("Det finns ingen väg härifrån.");
      return;
    }

    // The menu shows Swedish labels, but we switch on the enum - no string matching
    List<string> labels = [];
    foreach (Direction direction in directions)
    {
      labels.Add(Directions.Label(direction));
    }

    int choice = menu.Ask("Vart vill du gå?", labels);
    Direction selected = directions[choice - 1];

    switch (selected)
    {
      case Direction.North:
        TryMovePlayer(-1, 0);
        break;
      case Direction.South:
        TryMovePlayer(1, 0);
        break;
      case Direction.West:
        TryMovePlayer(0, -1);
        break;
      case Direction.East:
        TryMovePlayer(0, 1);
        break;
    }
  }

  private void TryMovePlayer(int rowMove, int colMove)
  {
    if (rowMove != 0 && colMove != 0)
    {
      Console.WriteLine("Du kan bara flytta dig i en riktning i taget");
    }
    else if (map.PositionExists(player.Row + rowMove, player.Col + colMove))
    {
      player.Row = player.Row + rowMove;
      player.Col = player.Col + colMove;
    }
    else
    {
      Console.WriteLine("Du kan inte gå åt det hållet.");
    }
  }

  // Lists the items lying around at this location
  void SearchLocation()
  {
    Location location = CurrentLocation();
    if (location.Items.Count == 0)
    {
      Console.WriteLine("Du hittar inget löst föremål här.");
      return;
    }
    foreach (Item item in location.Items)
    {
      Console.WriteLine($"Du hittar {item.Name}: {item.Description}");
    }
  }

  // Moves one item from the location into the player's backpack
  void TakeItem()
  {
    Location location = CurrentLocation();
    if (location.Items.Count == 0)
    {
      Console.WriteLine("Det finns inget föremål att ta.");
      return;
    }

    List<string> names = [];
    foreach (Item item in location.Items)
    {
      names.Add(item.Name);
    }

    int choice = menu.Ask("Vad vill du ta?", names);
    Item chosen = location.Items[choice - 1];
    location.Items.Remove(chosen);
    player.Backpack.Add(chosen);
  }

  // Polymorphism: the location's real class decides which Interact runs
  void Interact()
  {
    CurrentLocation().Interact(player);
    if (player.GameOver)
    {
      isRunning = false;
    }
  }

}
