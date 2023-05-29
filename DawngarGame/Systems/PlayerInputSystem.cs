using System;
using Dawngar.Commands;
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
        if(InputManager.Instance.IsKeyPressed(Keys.D))
        {
            World.Publish<PlayerMoveCommand>(new(eMoveDirection.EAST));
        }
        else if(InputManager.Instance.IsKeyPressed(Keys.A))
        {
            World.Publish<PlayerMoveCommand>(new(eMoveDirection.WEST));
        }
        else if(InputManager.Instance.IsKeyPressed(Keys.W))
        {
            World.Publish<PlayerMoveCommand>(new(eMoveDirection.NORTH));
        }
        else if(InputManager.Instance.IsKeyPressed(Keys.S))
        {
            World.Publish<PlayerMoveCommand>(new(eMoveDirection.SOUTH));
        }
    }
}