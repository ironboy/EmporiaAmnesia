class Map
{
  // Row 0 is north, column 0 is west. null = nothing there.
  // See docs/SYNOPSIS.md for which group owns which locations.
  public Location?[][] locations =
  [
    [null,               null,               new Escalator1(),         new Roof(),                new ParkingDeck(),  null],
    [new Foyer(),        new Escalator2(),   new CorridorA(),          null,                      null,               null],
    [new ToiletStall(),  null,               new OutsideDryCleaner(),  new CorridorB(),           null,               null],
    [null,               null,               new DryCleaner(),         new SecurityOffice(),      new TaxiStation(),  new Wedding()],
    [null,               null,               new BackRoom(),           new SurveillanceRoom(),    null,               null]
  ];



  public Location GetLocation(int row, int col)
  {
    return locations[row][col]!; // ! assertion, we promise this will exist
  }


  public bool PositionExists(int row, int col)
  {

    if (row < 0 || row >= locations.Length) // is row out of bounds?
    {
      return false;
    }

    if (col < 0 || col >= locations[row].Length) // is col out of bounds?
    {
      return false;
    }

    if (locations[row][col] == null) // is position on a null "cell"?
    {
      return false;
    }

    return true;

  }



}
