namespace AP.Core;

/// <summary>
///     Can be used like: Direction dir = Direction.Up | Direction.Right (up or right)
/// </summary>
[Flags]
public enum Direction
{
    None = 0,
    North = 1 << 0, // 0001
    South = 1 << 1, // 0010
    West = 1 << 2, // 0100
    East = 1 << 3 // 1000
}

public static class DirectionExtensions
{
    public static (int x, int y) ToCoordinates(this Direction direction, int multiplier = 1)
    {
        var x = 0;
        var y = 0;
        if (direction.HasFlag(Direction.North)) y -= multiplier;
        if (direction.HasFlag(Direction.South)) y += multiplier;
        if (direction.HasFlag(Direction.East)) x += multiplier;
        if (direction.HasFlag(Direction.West)) x -= multiplier;
        return (x, y);
    }
}