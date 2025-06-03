using System.Numerics;
using AP.Core;
using AP.Core.Ecs;
using Arch.Core;
using Arch.Core.Extensions;

namespace AP.Server;

public static class EntityFactory
{
    public static void SpawnTile(World world, WorldTile tile)
    {
        world.Create(
            new TileComponent(tile.Type, Guid.NewGuid()),
            new PositionComponent(new Vector2(tile.X, tile.Y))
        );
    }

    public static void SpawnTiles(World world, WorldTile[] tiles)
    {
        var amount = tiles.Length;
        Span<Entity> span = stackalloc Entity[amount];
        world.Create(span, [typeof(TileComponent), typeof(PositionComponent)], amount);
        for (var i = 0; i < amount; i++)
        {
            ref var entity = ref span[i];
            entity.Set(
                new TileComponent(tiles[i].Type, Guid.NewGuid()),
                new PositionComponent(new Vector2(tiles[i].X, tiles[i].Y))
            );
        }
    }

    public static void SpawnEntity(World world, WorldEntity entity)
    {
        var entityType = entity.Type;
        world.Create(
            new EntityComponent { Type = entityType, NetworkId = Guid.NewGuid() },
            new PositionComponent { Vector2 = new Vector2(entity.X, entity.Y) },
            new DirectionComponent { Direction = entity.Direction },
            new NextActionComponent { Action = EntityAction.None, Direction = Direction.None }
        );
    }

    public static void SpawnEntity(World world, WorldEntity entity, int peerId, Guid networkId)
    {
        var entityType = entity.Type;
        var newEntity = world.Create(
            new EntityComponent { Type = entityType, NetworkId = networkId },
            new PositionComponent { Vector2 = new Vector2(entity.X, entity.Y) },
            new DirectionComponent { Direction = entity.Direction },
            new NextActionComponent { Action = EntityAction.None, Direction = Direction.None }
        );
        newEntity.Add(new PlayerComponent
        {
            PeerId = peerId,
            SentAction = false
        });
    }

    public static void SpawnEntities(World world, WorldEntity[] entities)
    {
        var amount = entities.Length;
        Span<Entity> span = stackalloc Entity[amount];
        world.Create(span, [
            typeof(EntityComponent),
            typeof(PositionComponent),
            typeof(DirectionComponent),
            typeof(NextActionComponent)
        ], amount);
        for (var i = 0; i < amount; i++)
        {
            ref var entity = ref span[i];
            entity.Set(
                new EntityComponent { Type = entities[i].Type, NetworkId = Guid.NewGuid() },
                new PositionComponent { Vector2 = new Vector2(entities[i].X, entities[i].Y) },
                new DirectionComponent { Direction = entities[i].Direction },
                new NextActionComponent { Action = EntityAction.None, Direction = Direction.None }
            );
        }
    }
}