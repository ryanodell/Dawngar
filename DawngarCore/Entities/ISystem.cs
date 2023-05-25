namespace  DawngarCore.Entities;

public interface ISystem : IDisposable
{
    void Initialize(World world);
}