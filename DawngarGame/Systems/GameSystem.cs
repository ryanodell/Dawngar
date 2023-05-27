using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;

namespace Dawngar.Systems;

public class GameSystem : ISystem<GameTime>
{
    public bool IsEnabled { get; set; } = true;
    private readonly World _world;

    public GameSystem(World world)
    {
        _world = world;
    }
    
    public void Update(GameTime gameTime)
    {
    }

    public void Dispose() { }
}