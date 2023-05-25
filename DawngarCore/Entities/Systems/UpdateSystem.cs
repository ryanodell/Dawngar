using Microsoft.Xna.Framework;

namespace DawngarCore.Entities.Systems;

public interface IUpdateSystem : ISystem
{
    void Update(GameTime gameTime);
}

public abstract class UpdateSystem : IUpdateSystem
{
    public virtual void Initialize(World world) { }
    public virtual void Update(GameTime gameTime) { }
    public virtual void Dispose() { } 
}