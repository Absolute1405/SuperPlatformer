using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubleAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animation;
    private Bubbul_Behaviour _behaviour;
    void Start()
    {
        _behaviour = _animation.GetBehaviour<Bubbul_Behaviour>();
        _animation.SetBool("Start", true);
        _behaviour.ExitState += Destroyind;
    }
    private void Destroyind(bool bol)
    {
        _behaviour.ExitState -= Destroyind;
        Destroy(gameObject);
    }


}
