using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Spike-Trap Config", menuName = "Configs/Traps/SpikeTrap", order = 0)]
public class SpikeTrapConfig : ScriptableObject
{
    [SerializeField, Min(0)] private int _damage;
    [SerializeField, Min(0.001f)] private float _timer;
    [SerializeField] private DamageType _type;
    public float Timer => _timer;
    public int Damage => _damage;
    public DamageType Type => _type;
}