using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private int _TimerTime;
    public async Task MoveTask()
    {
        transform.Translate(new Vector3(Time.deltaTime, 0, 0));
        
    }
}
