using System;
using Dawngar.Components;
using DawngarCore.Commands;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;

namespace Dawngar.Systems;

[With(typeof(OverworldNpc)), With(typeof(DrawInfo))]
public class OverworldNpcSystem : AEntitySetSystem<GameTime>
{
    private static Random _rand;
    private readonly float _speed = 3.5f;
    public OverworldNpcSystem(World world) : base(world) 
    {
        _rand = new Random();
    }

    protected override void Update(GameTime gameTime, in Entity entity)
    {
        var direction = _rand.Next(0, 5);
        ref DrawInfo drawInfo = ref entity.Get<DrawInfo>();
        if(direction == 1) 
        {
            drawInfo.Position.X  += _speed;
        }
        if(direction == 2) 
        {
            drawInfo.Position.X  -= _speed;
        }
        if(direction == 3) 
        {
            drawInfo.Position.Y  += _speed;
        }
        if(direction == 4) 
        {
            drawInfo.Position.Y  -= _speed;
        }
    }

}