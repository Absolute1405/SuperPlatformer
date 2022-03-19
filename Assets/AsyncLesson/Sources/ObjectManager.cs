using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private ExampleObject _obj1;
    [SerializeField] private ExampleObject _obj2;

    private void Start()
    {
        AsyncTogether();
    }

    private IEnumerator CoroutineOrder()
    {
        yield return _obj1.RotateCoroutine();
        yield return _obj2.RotateCoroutine();
    }

    private async void AsyncOrder()
    {
        var delay = _obj1.RotateAsyncAndGetSecond();
        Debug.Log(delay);
        await _obj2.RotateAsync();
    }

    private async void AsyncTogether()
    {
        var tasks = new Task[2];
        tasks[0] = _obj1.RotateAsync();
        tasks[1] = _obj2.RotateAsync();

        await Task.WhenAny(tasks);
        Debug.Log("End");
    }
}
