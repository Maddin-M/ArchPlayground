using AP.Core;
using AP.Core.Ecs;
using Arch.Core;
using Arch.System;

namespace AP.Server;

public class MovementSystem(World world) : BaseSystem<World, float>(world)
{
    private readonly QueryDescription _getMovementEntities =
        new QueryDescription().WithAll<PositionComponent, NextActionComponent>();

    public override void Update(in float _)
    {
        World.Query(in _getMovementEntities, (ref PositionComponent position, ref NextActionComponent nextAction) =>
        {
            if (nextAction.Action != EntityAction.Move) return;
            var (deltaX, deltaY) = nextAction.Direction.ToCoordinates();
            position.Vector2.X += deltaX;
            position.Vector2.Y += deltaY;
        });
    }
}