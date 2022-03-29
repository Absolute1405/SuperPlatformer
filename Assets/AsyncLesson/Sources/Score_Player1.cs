using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Score_Player1 : Score_Counter
{
    public void Attacking (int damage)
    {
        ToAttack(damage);
    }

}
