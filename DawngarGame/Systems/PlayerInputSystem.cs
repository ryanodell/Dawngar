using System;
using Dawngar.Components;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Dawngar;

[With(typeof(PlayerInput))]
public class PlayerInputSystem : AEntitySetSystem<GameTime>
{
    public PlayerInputSystem(World world) : base(world)
    {

    }

    protected override void Update(GameTime state, in Entity entity)
    {
        ref DrawInfo drawInfo = ref entity.Get<DrawInfo>();
        if(InputManager.Instance.IsKeyPressed(Keys.A)) 
        {
            drawInfo.Position.X = drawInfo.Position.X + 1;
        }
    }
}