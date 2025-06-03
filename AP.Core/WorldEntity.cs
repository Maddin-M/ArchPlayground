namespace AP.Core;

public struct WorldEntity
{
    public EntityType Type { get; init; }
    public int X { get; init; }
    public int Y { get; init; }
    public Direction Direction { get; init; }
}