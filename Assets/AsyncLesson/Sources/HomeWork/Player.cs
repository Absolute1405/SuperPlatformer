using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

namespace Game
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Text _text;
        [SerializeField] private int _critFactor = 2;
        [SerializeField] private CriticalHit _critical;

        public event Action<Player> Won;
        
        public int Score { get; private set; } = 0;
        private const int clickCost=25;
        private int _maxScore;

        public void StartTurn(int maxScore)
        {
            _button.onClick.AddListener(OnClick);
            _maxScore = maxScore;
        }

        public void StopTurn()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            if (_critical.TakeCriticalByChance())
            {
                Score += clickCost*_critFactor;
            }
            else
            {
                Score += clickCost;
            }
            
            _text.text = "Score " + Score.ToString();

            if (Score >= _maxScore)
            {
                _maxScore = Score;
                Won?.Invoke(this);
            }
        }
    }
}

