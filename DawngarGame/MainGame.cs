using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DawngarCore;

namespace Dawngar;

public class MainGame : Game
{
    private GraphicsDeviceManager _graphics;
    public SpriteBatch SpriteBatch;
    private Texture2D _texture;
    private Camera2D _camera;
    private SpriteFont _spriteFont;

    public MainGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Assets";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        Globals.GameRef =  this;
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatch = new SpriteBatch(GraphicsDevice);
        // string relativePath = "Characters/Avian.png";
        // string baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        // string filePath = Path.Combine(baseDirectory, relativePath);

        // using (var stream = new FileStream(filePath, FileMode.Open))
        // {
        //     _texture = Texture2D.FromStream(GraphicsDevice, stream);
        // }
        // _camera = new Camera2D(GraphicsDevice);
        // _camera.LookAt(Vector2.Zero);
        // _camera.Zoom = 3f;
        // _spriteFont = Content.Load<SpriteFont>("../Fonts/SDS_8x8");
        ScreenManager.Instance.ChangeScreen(new TempEditor());
    }

    protected override void Update(GameTime gameTime)
    {
        InputManager.Instance.Update(gameTime);
        ScreenManager.Instance.Update(gameTime);
        // if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        // {
        //     Exit();
        // }


        // if (InputManager.Instance.IsKeyPressed(Keys.A))
        // {
            
        // }


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        ScreenManager.Instance.Draw(SpriteBatch,  gameTime);

        // _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _camera.GetViewMatrix());
        // _spriteBatch.Draw(_texture, Vector2.Zero, Color.White);
        // _spriteBatch.DrawString(_spriteFont, "fudge", Vector2.Zero, Color.Red);
        // _spriteBatch.End();

        base.Draw(gameTime);
    }
}
