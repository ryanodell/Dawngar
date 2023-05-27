using System;
using Dawngar.Components;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Dawngar;

[With(typeof(PlayerInput))]
public class PlayerSystem : AEntitySetSystem<GameTime>
{
    public PlayerSystem(World world) : base(world)
    {

    }

    protected override void Update(GameTime state, in Entity entity)
    {
        ref Position position = ref entity.Get<Position>();
        if(InputManager.Instance.IsKeyPressed(Keys.A)) 
        {

        }
    }
}