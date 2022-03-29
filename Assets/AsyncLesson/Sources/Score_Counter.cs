using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Counter : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private Text _text;

    private void Start()
    {
        UpdateScore();
    }
    private void UpdateScore()
    {
        _text.text = "Score" + _score.ToString() ;
        if (_score >= 300)
        {

        }
    }
    public void ToAttack(int damage)
    {
       _score += damage;
        UpdateScore();
    }
}
