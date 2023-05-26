using DefaultEcs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dawngar;
//6168310

public class TempEditor : ScreenBase
{
    World _world;
    public override void LoadContent()
    {
        _world = new World(10);
    }

    public override void UnloadContent()
    {

    }

    public override void Update(GameTime gameTime)
    {

    }

    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        
    }
}