using UnityEngine;

public class MeleeEnemyAnimator : EnemyAnimator
{
    [SerializeField] private string _moveBool = "Move";

    public void Move(bool value)
    {
        Animator.SetBool(_moveBool, value);
    }
}
