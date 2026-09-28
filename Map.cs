class Map
{
  // Row 0 is north, column 0 is west. null = nothing there.
  // See docs/SYNOPSIS.md for which group owns which locations.

  public static Location?[][] Locations =
  [
    [new Roof2(),               null,               new Escalator1(),         new Roof(),                new ParkingDeck(),  null],
    [new Foyer(),               new Escalator2(),   new CorridorA(),          null,                      null,               null],
    [new ToiletStall(),         null,               new OutsideDryCleaner(),  new CorridorB(),           null,               null],
    [null,                      null,               new DryCleaner(),         new SecurityOffice(),      new TaxiStation(),  new Wedding()],
    [new Staffarea1(),          new Staffarea2(),   new BackRoom(),           new SurveillanceRoom(),    null,               null]
  ];


  // A static constructor runs once, after the static fields above have been
  // built - so this is the first moment the whole map exists. Every location
  // that hasn't chosen its own exits gets them from the map here.
  static Map()
  {
    for (int row = 0; row < Locations.Length; row++)
    {
      for (int col = 0; col < Locations[row].Length; col++)
      {
        Location? location = Locations[row][col];
        if (location != null && location.Directions.Length == 0)
        {
          location.Directions = DirectionsFor(row, col);
        }
      }
    }
  }

  // The exits of a location, worked out from the map. Call this from a
  // location to reopen its exits, e.g. Directions = Map.DirectionsFor(this);
  public static Direction[] DirectionsFor(Location location)
  {
    for (int row = 0; row < Locations.Length; row++)
    {
      for (int col = 0; col < Locations[row].Length; col++)
      {
        if (Locations[row][col] == location)
        {
          return DirectionsFor(row, col);
        }
      }
    }
    return []; // not on the map
  }

  // The exits of a position, worked out from which neighbours exist on the map
  public static Direction[] DirectionsFor(int row, int col)
  {
    List<Direction> exits = [];
    if (PositionExists(row - 1, col)) { exits.Add(Direction.North); }
    if (PositionExists(row + 1, col)) { exits.Add(Direction.South); }
    if (PositionExists(row, col - 1)) { exits.Add(Direction.West); }
    if (PositionExists(row, col + 1)) { exits.Add(Direction.East); }
    return [.. exits];
  }

  public Location GetLocation(int row, int col)
  {
    return Locations[row][col]!; // ! assertion, we promise this will exist
  }


  public static bool PositionExists(int row, int col)
  {

    if (row < 0 || row >= Locations.Length) // is row out of bounds?
    {
      return false;
    }

    if (col < 0 || col >= Locations[row].Length) // is col out of bounds?
    {
      return false;
    }

    if (Locations[row][col] == null) // is position on a null "cell"?
    {
      return false;
    }

    return true;

  }



}
