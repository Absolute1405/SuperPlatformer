using Platformer.Characters;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField] private Image _bar;
        [SerializeField] private Health _health;

        public void RefreshBar()
        {
            _bar.fillAmount = (float) _health.Value / _health.MaxValue;
        }
    }
}