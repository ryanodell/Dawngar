using Microsoft.Xna.Framework;

namespace Dawngar.Systems;

public struct BasicAnimation
{
    public Rectangle[] AnimationRects;
    public int CurrentFrame;
    public float AnimationTimer;
    public float AnimationSpeed;
}