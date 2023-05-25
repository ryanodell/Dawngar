
using Dawngar.Components;
using DawngarCore.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dawngar;

public class TempEditor : ScreenBase
{
    private World _world;
    private Entity _entityTest;

    public override void LoadContent()
    {
        _world = new World();
        _entityTest = _world.CreateEntity();
        _entityTest.AddComponent<Transform>(new Transform 
        { 
            Position = Vector2.Zero, 
            Color = Color.White, 
            SourceRect = new Rectangle(2, 0, 16, 16) 
        });
        _entityTest.AddComponent<Moveable>();
    }

    public override void UnloadContent()
    {

    }

    public override void Update(GameTime gameTime)
    {
        _world.Update(gameTime);
        if(_entityTest.Has<Moveable>()) 
        {
            var test = "";
        }
        if(_entityTest.Has<Transform>()) 
        {
            var trans = _entityTest.GetComponent<Transform>();
        }
    }

    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        
    }
}