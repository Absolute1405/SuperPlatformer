using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timerView;

    private bool _stopped;

    public async Task WaitForSeconds(int seconds)
    {
        _stopped = false;

        for (int i = seconds; i >= 0; i--)
        {
            _timerView.text = i.ToString();
            await WaitSecond();

            if (_stopped)
                break;
        }
    }

    private async Task WaitSecond()
    {
        await Task.Delay(1000);
    }

    public void StopTimer()
    {
        _stopped = true;
    }
}
