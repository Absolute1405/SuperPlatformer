using System.Collections.Generic;
using UnityEngine;

public class TrapContainer : MonoBehaviour
{
    private List<Trap> _traps;

    public void Initialize()
    {
        Trap[] traps = GetComponentsInChildren<Trap>();

        if (traps.Length == 0)
            return;

        _traps.AddRange(traps);

    }
}
