using UnityEngine;

[CreateAssetMenu(fileName = "New Player Config", menuName = "Configs/Player", order = 0)]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _jumpForce = 20f;
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _acceleration = 0.2f;

    public int MaxHealth => _maxHealth;
    public int Damage => _damage;
    public float JumpForce => _jumpForce;
    public float MaxSpeed => _maxSpeed;
    public float Acceleration => _acceleration;
}
