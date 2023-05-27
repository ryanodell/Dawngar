namespace Dawngar.Commands;
public readonly struct MovePlayer 
{
    public readonly string Direction;
    public MovePlayer(string direction) 
    {
        Direction = direction;
    }
}