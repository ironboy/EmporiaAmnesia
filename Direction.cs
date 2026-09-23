// The four ways the player can move. An enum instead of strings like "Norr":
// a misspelling is now a compile error instead of a silently broken exit.
enum Direction
{
  North,
  South,
  West,
  East
}

// Static helpers for directions. No object is needed - you call them on the
// class itself: Directions.Label(Direction.North) gives "Norr".
static class Directions
{
  public static string Label(Direction direction)
  {
    switch (direction)
    {
      case Direction.North: return "Norr";
      case Direction.South: return "Söder";
      case Direction.West: return "Väster";
      case Direction.East: return "Öster";
      default: return direction.ToString();
    }
  }
}
