using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private string _attackTrigger = "Attack";
    [SerializeField] private string _hurtTrigger = "Hurt";
    [SerializeField] private string _deathTrigger = "Death";

    protected Animator Animator => _animator;
    protected SpriteRenderer Renderer => _renderer;

    public void Attack()
    {
        _animator.SetTrigger(_attackTrigger);
    }

    public void Hurt()
    {
        _animator.SetTrigger(_hurtTrigger);
    }

    public void Death()
    {
        _animator.SetTrigger(_deathTrigger);
    }

    public void SetFlip(bool value)
    {
        _renderer.flipX = value;
    }
}
