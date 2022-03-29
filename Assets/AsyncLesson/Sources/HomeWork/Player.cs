using System.Collections;
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
        private const int delayConst = 1000;

        private TaskCompletionSource<int> _clickTask;

        public async Task Play(float time, int maxScore)
        {
            _button.onClick.AddListener(OnClick);
            var durationTask = WaitDuration(time);
            var scoreTask = WaitMaxScore(maxScore);

            await Task.WhenAny(durationTask, scoreTask);

            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            Score += clickCost;
            _text.text = "Score " + Score.ToString();

            _clickTask.SetResult(Score);
        }

        private async Task WaitDuration(float seconds)
        {
            var ms = delayConst * seconds;
            await Task.Delay((int)ms);
        }

        private async Task WaitMaxScore(int maxScore)
        {
            int result = 0;

            while (result < maxScore)
            {
                _clickTask = new TaskCompletionSource<int>();
                result = await _clickTask.Task;
            }
        }
    }
}

