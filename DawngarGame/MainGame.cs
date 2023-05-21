using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DawngarCore;
using Gtk;
using System;

namespace Dawngar;

public class MainGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _texture;
    private Camera2D _camera;

    public MainGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        string relativePath = "Characters/Avian.png";
        string baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string filePath = Path.Combine(baseDirectory, relativePath);

        using (var stream = new FileStream(filePath, FileMode.Open))
        {
            _texture = Texture2D.FromStream(GraphicsDevice, stream);
        }
        _camera = new Camera2D(GraphicsDevice);
        _camera.LookAt(Vector2.Zero);
        _camera.Zoom = 3f;
    }

    protected override void Update(GameTime gameTime)
    {
        InputManager.Instance.Update(gameTime);
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }


        if (InputManager.Instance.IsKeyPressed(Keys.A))
        {
            
        }


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _camera.GetViewMatrix());
        _spriteBatch.Draw(_texture, Vector2.Zero, Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
