using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Healthbar _healthbar;
    public Healthbar Healthbar => _healthbar;
    private void Initialize ()
    {
        
    }
}
