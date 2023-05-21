using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class ScreenBase
    {
        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }