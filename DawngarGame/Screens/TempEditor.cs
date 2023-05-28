using DefaultEcs;
using Dawngar.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DefaultEcs.System;
using DawngarCore;
using Dawngar.Systems;
using Dawngar.Loaders;
using DawngarCore.Commands;
using DefaultEcs.Resource;

namespace Dawngar;

public class TempEditor : ScreenBase
{
    World _world;
    Entity _player;
    TextureResourceManager _textureResourceManager;
    private ISystem<GameTime> _system;
    private ISystem<GameTime> _drawingSystem;
    private Texture2D _texture;
    private Camera2D _camera;

    public override void LoadContent()
    {
        _textureResourceManager = new TextureResourceManager(Globals.GameRef.GraphicsDevice, new FsTextureLoader());
        _camera = new Camera2D(Globals.GameRef.GraphicsDevice);
        _camera.LookAt(Vector2.Zero);
        _camera.Zoom = 2f;
        _world = new World(101);
        _player = _world.CreateEntity();
        _player.Set<PlayerInput>();
        _player.Set<DrawInfo>(new DrawInfo { 
            Position = Vector2.Zero, 
            Color = Color.White, 
            SourceRect = new Rectangle(0, 0, 16, 16)
        });
        
        _player.Set(ManagedResource<Texture2D>.Create("Characters/Player.png"));

        for(int i = 0; i < 100; i++) 
        {
            var npc = _world.CreateEntity();
            npc.Set<OverworldNpc>();
            npc.Set(new DrawInfo 
            {
                Position = Vector2.Zero,
                Color = Color.White,
                SourceRect = new Rectangle(16, 16, 16, 16)
            });
            npc.Set(ManagedResource<Texture2D>.Create("Characters/Avian.png"));
        }
        _system =  new SequentialSystem<GameTime>(
            new GameSystem(_world),
            new PlayerInputSystem(_world),
            new AnimationSystem(_world),
            new OverworldNpcSystem(_world)
        );
        _drawingSystem = new DrawingSystem(_world, Globals.GameRef.SpriteBatch, _camera);
        _textureResourceManager.Manage(_world);
    }

    public override void UnloadContent()
    {
        _system.Dispose();
        _drawingSystem.Dispose();
        _textureResourceManager.Dispose();
    }

    public override void Update(GameTime gameTime)
    {
        _system.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) 
    {
        _drawingSystem.Update(gameTime);
    }
}