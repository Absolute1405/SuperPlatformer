using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _movement;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Direction direction, float speed)
    {
        _movement = DirectionGetter.GetVectorFromDirection(direction);
        _rigidbody.velocity = _movement * speed;
    }

    public void Stop()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}
