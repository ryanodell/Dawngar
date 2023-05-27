using DefaultEcs;
using Dawngar.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DefaultEcs.System;

namespace Dawngar;

public class TempEditor : ScreenBase
{
    World _world;
    Entity _player;
    private ISystem<GameTime> _system;

    public override void LoadContent()
    {
        _world = new World(10);
        _player = _world.CreateEntity();
        _player.Set<PlayerInput>();
        _player.Set<Position>(new Position(Vector2.Zero));
        _system =  new SequentialSystem<GameTime>(new PlayerSystem(_world));
    }

    public override void UnloadContent()
    {

    }

    public override void Update(GameTime gameTime)
    {
        _system.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        
    }
}