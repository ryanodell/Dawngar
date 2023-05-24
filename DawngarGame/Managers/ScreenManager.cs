using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dawngar;

public class ScreenManager
{
    private static ScreenManager instance;
    public ScreenBase CurrentScreen { private set; get; }
    public static ScreenManager Instance
    {
        get
        {
            if (instance == null)
                instance = new ScreenManager();
            return instance;
        }
    }
    public ScreenManager() { }

    public void ChangeScreen(ScreenBase screen)
    {
        CurrentScreen?.UnloadContent();
        CurrentScreen = screen;
        CurrentScreen.LoadContent();
    }

    public void LoadContent()
    {
        if (CurrentScreen != null)
            CurrentScreen.LoadContent();
    }

    public void Update(GameTime gameTime)
    {
        if (CurrentScreen != null)
            CurrentScreen.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        if (CurrentScreen != null)
            CurrentScreen.Draw(spriteBatch, gameTime);
    }
}