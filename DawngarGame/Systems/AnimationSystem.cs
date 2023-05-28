using System;
using Dawngar.Components;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;

namespace Dawngar.Systems;

[With(typeof(BasicAnimation)), With(typeof(DrawInfo))]
public class AnimationSystem : AEntitySetSystem<GameTime>
{
    public AnimationSystem(World world) : base(world) { }

    protected override void Update(GameTime gameTime, ReadOnlySpan<Entity> entities)
    {
        foreach(var entity in entities)
        {
            ref BasicAnimation animation = ref entity.Get<BasicAnimation>();
            animation.AnimationTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(animation.AnimationTimer <= 0) 
            {
                animation.CurrentFrame ^= 1;
                animation.AnimationTimer = animation.AnimationSpeed;
                ref DrawInfo drawInfo = ref entity.Get<DrawInfo>();
                drawInfo.SourceRect = animation.AnimationRects[animation.CurrentFrame];
            }
        }
        base.Update(gameTime, entities);
    }
}