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

        public int Score { get; private set} = 0;
        private const int clickCost=25;
        private const int delayConst = 1000;

        public async Task Play(float time)
        {
            _button.onClick.AddListener(OnClick);
            var ms = delayConst * time;
            await Task.Delay((int)ms);
            _button.onClick.RemoveListener(OnClick);
        }
        private void OnClick()
        {
            Score += clickCost;
            _text.text = "Score " + Score.ToString();
        }
    }
}

