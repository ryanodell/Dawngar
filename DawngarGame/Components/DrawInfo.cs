using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dawngar.Components;


public struct DrawInfo 
{
    public Texture2D Texture;
    public Rectangle SourceRect;
    public Color Color;
    public Vector2 Position;
}