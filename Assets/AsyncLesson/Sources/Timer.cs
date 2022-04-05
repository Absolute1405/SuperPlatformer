using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timerView;

    public async Task WaitForSeconds(int seconds)
    {
        for (int i = seconds; i >= 0; i++)
        {
            _timerView.text = i.ToString();
            await WaitSecond();
        }
    }

    private async Task WaitSecond()
    {
        await Task.Delay(1000);
    }
}
