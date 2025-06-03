using AP.Core;
using Arch.Core;
using Arch.System;
using Schedulers;

namespace AP.Server;

public class Server
{
    private JobScheduler _jobScheduler;
    private Group<float> _systems;
    private World _world;

    public void Start()
    {
        _world = World.Create();
        _jobScheduler = new JobScheduler(
            new JobScheduler.Config
            {
                ThreadPrefixName = "Dungeons.Server",
                ThreadCount = 0,
                MaxExpectedConcurrentJobs = 64,
                StrictAllocationMode = false
            }
        );
        World.SharedJobScheduler = _jobScheduler;

        _systems = new Group<float>(
            "ServerSystems",
            new MovementSystem(_world)
        );
        _systems.Initialize();

        #region this would have come from a world generator

        WorldTile[] worldTiles =
        [
            new() { Type = TileType.Floor1, X = 0, Y = 0 }, new() { Type = TileType.Floor1, X = 1, Y = 0 },
            new() { Type = TileType.Floor1, X = 0, Y = 1 }, new() { Type = TileType.Floor1, X = 1, Y = 1 }
        ];
        WorldEntity[] worldEntities =
        [
            new() { Type = EntityType.Peasant, X = 0, Y = 0 }, new() { Type = EntityType.Peasant, X = 1, Y = 0 },
            new() { Type = EntityType.Peasant, X = 0, Y = 1 }, new() { Type = EntityType.Peasant, X = 1, Y = 1 }
        ];

        #endregion
        
        EntityFactory.SpawnTiles(_world, worldTiles);
        EntityFactory.SpawnEntities(_world, worldEntities);
    }
    
    public void Update()
    {
        // updates the network manager etc
    }

    public void Stop()
    {
        // stop server
    }
}