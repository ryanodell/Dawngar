using Dawngar.Components;
using Dawngar.Loaders;
using DefaultEcs;
using DefaultEcs.Resource;
using Microsoft.Xna.Framework.Graphics;

namespace Dawngar;

public sealed class TextureResourceManager : AResourceManager<string, Texture2D>
{
    private readonly GraphicsDevice _graphiceDevice;
    private readonly ITextureLoader _textureLoader;
    public TextureResourceManager(GraphicsDevice graphicsDevice, ITextureLoader textureLoader)
    {
        _graphiceDevice = graphicsDevice;
        _textureLoader = textureLoader;
    }

    protected override Texture2D Load(string textureName) => _textureLoader.Load(textureName);

    protected override void OnResourceLoaded(in Entity entity, string textureName, Texture2D resource)
    {
        entity.Get<DrawInfo>().Texture = resource;
    }
}