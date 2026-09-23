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

  public void Teleport(int row, int col)
  {
    Row = row;
    Col = col;
  }

}
