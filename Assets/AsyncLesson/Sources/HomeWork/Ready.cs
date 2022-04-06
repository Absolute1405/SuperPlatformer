using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Ready : MonoBehaviour
{
    [SerializeField] private Button _button;
    private TaskCompletionSource<bool> _completionSource;
    public async Task WaitClick()
    {
        _button.onClick.AddListener(OnClick);

        _completionSource = new TaskCompletionSource<bool>();
        await _completionSource.Task;

        _button.onClick.RemoveListener(OnClick);
    }
    private void OnClick()
    {
        _completionSource.SetResult(true);
    }
}
