using DefaultEcs;
using DefaultEcs.System;
using DawngarCore;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Dawngar.Components;

namespace Dawngar;

[With(typeof(DrawInfo))]
public class DrawingSystem : AComponentSystem<GameTime, DrawInfo>
{
    private SpriteBatch _spriteBatch;
    private Camera2D _camera;

    public DrawingSystem(World world, SpriteBatch spriteBatch, Camera2D camera) : base(world)
    {
        _spriteBatch = spriteBatch;
        _camera = camera;
    }

    protected override void PreUpdate(GameTime gameTime) => 
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _camera.GetViewMatrix());
    protected override void Update(GameTime state, ref DrawInfo component)
    {
        _spriteBatch.Draw(component.Texture, component.Position, component.SourceRect, component.Color);
    }
    protected override void PostUpdate(GameTime gameTime) => _spriteBatch.End();

}