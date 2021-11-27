using UnityEngine;

public class MeleeEnemyAnimator : EnemyAnimator
{
    [SerializeField] private string _moveBool = "Move";
    [SerializeField] private SpriteRenderer _renderer;

    public void Move(bool value)
    {
        Animator.SetBool(_moveBool, value);
    }
}
