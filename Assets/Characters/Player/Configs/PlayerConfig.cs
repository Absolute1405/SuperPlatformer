using UnityEngine;

[CreateAssetMenu(fileName = "New Player Config", menuName = "Configs/Player", order = 0)]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _maxStamina = 100;
    [SerializeField] private float _jumpForce = 20f;
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _acceleration = 0.2f;
    [SerializeField] private int _maxSleep = 5;

    public int MaxHealth => _maxHealth;
    public int MaxStamina => _maxStamina;
    public float JumpForce => _jumpForce;
    public float MaxSpeed => _maxSpeed;
    public float Acceleration => _acceleration;
    public int MaxSleep => _maxSleep;
}
 