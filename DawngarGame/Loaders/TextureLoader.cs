using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework.Graphics;
namespace Dawngar.Loaders;

public interface ITextureLoader 
{
    Texture2D Load(string relativePath);
    void LoadAllAssetsIntoMemory();
}

public class FsTextureLoader : ITextureLoader
{
    private Dictionary<string, Texture2D> _textureCache = new Dictionary<string, Texture2D>();
    public Texture2D Load(string relativePath)
    {
        if(_textureCache.TryGetValue(relativePath, out var _))
        {
            return _textureCache[relativePath];
        }
        Texture2D texture;
        string baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string filePath = Path.Combine(baseDirectory, relativePath);
        using var stream = new FileStream(filePath, FileMode.Open);        
        texture = Texture2D.FromStream(Globals.GameRef.GraphicsDevice, stream);
        _textureCache.Add(relativePath, texture);
        return texture;
    }

    public void LoadAllAssetsIntoMemory()
    {
        throw new System.NotImplementedException();
    }
}