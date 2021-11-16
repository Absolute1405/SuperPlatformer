using UnityEngine;

public static class DirectionGetter 
{
    public static Vector2 GetVectorFromDirection(Direction direction)
    {
        switch (direction)
        {
            default:
                return Vector2.zero;
            case Direction.Right:
                return Vector2.right;
            case Direction.Left:
                return Vector2.left;
            case Direction.Up:
                return Vector2.up;
            case Direction.Down:
                return Vector2.down;
        }
    }

    public static Direction GetReversed(Direction direction)
    {
        switch (direction)
        {
            default:
                return Direction.None;
            case Direction.Right:
                return Direction.Left;
            case Direction.Left:
                return Direction.Right;
            case Direction.Up:
                return Direction.Down;
            case Direction.Down:
                return Direction.Up;
        }
    }
}
