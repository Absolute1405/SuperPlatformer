﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

namespace Game
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Text _text;

        public int Score { get; private set; } = 0;
        private const int clickCost=25;

        private TaskCompletionSource<int> _clickTask;

        public async Task Play(int maxScore)
        {
            _button.onClick.AddListener(OnClick);

            while (Score < maxScore)
            {
                _clickTask = new TaskCompletionSource<int>();
                Score = await _clickTask.Task;
            }

            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            Score += clickCost;
            _text.text = "Score " + Score.ToString();

            _clickTask.SetResult(Score);
        }
    }
}

