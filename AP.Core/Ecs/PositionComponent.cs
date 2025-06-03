using System.Numerics;

namespace AP.Core.Ecs;

public struct PositionComponent(Vector2 position)
{
    public Vector2 Vector2 = position;
}