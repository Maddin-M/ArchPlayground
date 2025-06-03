namespace AP.Core.Ecs;

public struct TileComponent(TileType tileType, Guid networkId)
{
    public TileType Type = tileType;
    public Guid NetworkId = networkId;
}