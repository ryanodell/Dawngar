using System;
using Dawngar.Commands;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;

namespace Dawngar.Systems;

public sealed class GameSystem : ISystem<GameTime>
{
    public bool IsEnabled { get; set; } = true;
    private readonly World _world;

    public GameSystem(World world)
    {
        _world = world;
        _world.Subscribe<PlayerMoveCommand>(on_InputCommand);
    }
    
    public void Update(GameTime gameTime)
    {
    }

    public void Dispose() { }

    private void on_InputCommand(in PlayerMoveCommand moveCommand) 
    {
        
        Console.WriteLine(moveCommand.Direction);
    }
}