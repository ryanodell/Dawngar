using DefaultEcs.System;
using Microsoft.Xna.Framework;

namespace Dawngar.Systems;

public class GameSystem : ISystem<GameTime>
{
    public bool IsEnabled { get; set; } = true;

    public void Dispose()
    {
        
    }

    

    public void Update(GameTime gameTime)
    {
    }
}