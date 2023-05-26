using DefaultEcs.System;
using Microsoft.Xna.Framework;

namespace Dawngar.Systems;

public class GameSystem : ISystem<GameTime>
{
    public bool IsEnabled { get; set; } = true;

    public void Dispose()
    {
        throw new System.NotImplementedException();
    }

    public void Update(GameTime state)
    {
        throw new System.NotImplementedException();
    }
}