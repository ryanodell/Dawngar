
using Dawngar.Components;
using DawngarCore.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dawngar;

public class TempEditor : ScreenBase
{
    private World _world;
    private Entity _someEntity;

    public override void LoadContent()
    {
        _world = new World();
        _someEntity = _world.CreateEntity();
        _someEntity.AddComponent<Transform>(new Transform 
        { 
            Position = Vector2.Zero, 
            Color = Color.White, 
            SourceRect = new Rectangle(2, 0, 16, 16) 
        });
        _someEntity.AddComponent<Moveable>();
    }

    public override void UnloadContent()
    {

    }

    public override void Update(GameTime gameTime)
    {
        _world.Update(gameTime);
        if(_someEntity.Has<Moveable>()) 
        {
            var test = "";
        }
        if(_someEntity.Has<Transform>()) 
        {
            var trans = _someEntity.GetComponent<Transform>();
        }
    }

    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        
    }
}