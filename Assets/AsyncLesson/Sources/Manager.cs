using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Manager : MonoBehaviour
{
    [SerializeField]private Timer _timer;
    private void Start()
    {
        Task();
    }
    private async Task Task()
    {

        await _timer.TamerAsync();
        Debug.Log("1");

    }
}
