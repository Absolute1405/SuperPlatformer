using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ExampleObject : MonoBehaviour
{
    [SerializeField] private ExampleObjectAnimator _animator;
    [SerializeField] private int _animDuration = 2;

    public IEnumerator RotateCoroutine()
    {
        _animator.Rotate(true);

        for (float i = 0; i < _animDuration; i += Time.deltaTime)
        {
            yield return null;
        }

        _animator.Rotate(false);
    }

    public async Task RotateAsync()
    {
        _animator.Rotate(true);

        await Task.Delay(_animDuration);

        _animator.Rotate(false);
    }

    public async Task<int> RotateAsyncAndGetSecond()
    {
        _animator.Rotate(true);

        await Task.Delay(_animDuration);

        _animator.Rotate(false);

        return _animDuration;
    }
}
