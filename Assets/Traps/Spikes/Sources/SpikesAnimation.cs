using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SpikesAnimation : MonoBehaviour
{
    [SerializeField] private string _activateTrigger = "Activate";
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        _animator.SetTrigger(_activateTrigger);
    }
}
