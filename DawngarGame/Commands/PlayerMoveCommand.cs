namespace Dawngar.Commands;
public readonly struct PlayerMoveCommand 
{
    public readonly eMoveDirection Direction;
    public PlayerMoveCommand(eMoveDirection direction) 
    {
        Direction = direction;
    }
}