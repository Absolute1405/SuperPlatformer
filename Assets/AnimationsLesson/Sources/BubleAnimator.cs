using UnityEngine;

public class BubleAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animation;
    [SerializeField] private string _startBool = "Start";
    private BubbleBehaviour _behaviour;

    void Start()
    {
        _behaviour = _animation.GetBehaviour<BubbleBehaviour>();
        _animation.SetBool(_startBool, true);
        _behaviour.ExitState += DestroyObject;
    }

    private void OnDestroy()
    {
        _behaviour.ExitState -= DestroyObject;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }


}
