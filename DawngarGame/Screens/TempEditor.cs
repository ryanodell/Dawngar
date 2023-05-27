using DefaultEcs;
using Dawngar.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DefaultEcs.System;
using System.Reflection;
using System.IO;
using DawngarCore;
using Dawngar.Systems;
using System.Collections.Generic;
using DawngarCore.Commands;

namespace Dawngar;

public class TempEditor : ScreenBase
{
    World _world;
    Entity _player;
    List<Entity> _overworldNpcs = new List<Entity>();
    private ISystem<GameTime> _system;
    private ISystem<GameTime> _drawingSystem;
    private Texture2D _texture;
    private Camera2D _camera;

    public override void LoadContent()
    {
        string relativePath = "Characters/Avian.png";
        string baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string filePath = Path.Combine(baseDirectory, relativePath);
        using (var stream = new FileStream(filePath, FileMode.Open))
        {
            _texture = Texture2D.FromStream(Globals.GameRef.GraphicsDevice, stream);
        }
        _camera = new Camera2D(Globals.GameRef.GraphicsDevice);
        _camera.LookAt(Vector2.Zero);
        _camera.Zoom = 2f;
        _world = new World(10_002);
        _player = _world.CreateEntity();
        _player.Set<PlayerInput>();
        _player.Set<DrawInfo>(new DrawInfo { 
            Position = Vector2.Zero, 
            Color = Color.White, 
            SourceRect = new Rectangle(0, 0, 16, 16), 
            Texture = _texture 
        });

        for(int i = 0; i < 10_000; i++) 
        {
            var npc = _world.CreateEntity();
            npc.Set<OverworldNpc>();
            npc.Set(new DrawInfo 
            {
                Position = Vector2.Zero,
                Color = Color.White,
                SourceRect = new Rectangle(16, 16, 16, 16),
                Texture = _texture
            });
            _overworldNpcs.Add(npc);
        }
        _system =  new SequentialSystem<GameTime>(
            new GameSystem(_world),
            new PlayerInputSystem(_world),
            new OverworldNpcSystem(_world)
        );
        _drawingSystem = new DrawingSystem(Globals.GameRef.SpriteBatch, _world, _camera);
    }

    public override void UnloadContent()
    {
        _system.Dispose();
        _drawingSystem.Dispose();
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