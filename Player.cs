class Player
{

  // The player's position in the map (see Map.cs)
  public int Row { get; set; }
  public int Col { get; set; }

  public Backpack Backpack { get; } = new();

  // Set this to true in an Interact to end the game (you made it to the wedding - or got arrested)
  public bool GameOver { get; set; }

  public Player(int startRow, int startCol)
  {
    Row = startRow;
    Col = startCol;
  }

  private void Teleport(int row, int col)
  {
    Row = row;
    Col = col;
  }

  public void Teleport(string classNameOfLocation)
  {
    // locs - just a shorter alias for Map.Locations
    var locs = Map.Locations;
    // loop through the rows
    for (var row = 0; row < locs.Length; row++)
    {
      // loop throught the columns
      for (var col = 0; col < locs[row].Length; col++)
      {
        // if empty location null - continue the loop
        // i.e. go directly the next iteration of the col loop
        if (locs[row][col] == null) { continue; }
        // compare the classNameOfLocation parameter
        // with the name of the class the the location object
        // is an instance of
        if (classNameOfLocation == locs[row][col]!.GetType().Name)
        {
          // use the other Teleport method that takes row and cols as inte
          // if we find a matching location
          Teleport(row, col);
          // do nothing more
          return;
        }
      }
    }
  }

}
