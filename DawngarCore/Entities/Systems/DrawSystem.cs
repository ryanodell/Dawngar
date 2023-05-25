using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DawngarCore.Entities.Systems;

public interface IDrawSystem : ISystem
{
    void Draw(SpriteBatch spriteBatch, GameTime gameTime);
}

public abstract class DrawSystem : IDrawSystem
{
    public virtual void Initialize(World world) { }
    public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime) { }
    public virtual void Dispose() { }
}