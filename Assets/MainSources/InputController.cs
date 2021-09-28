using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Player _player;

    public void SetPlayer(Player player)
    {
        if (player is null)
            throw new ArgumentNullException(nameof(player));

        _player = player;
    }

    private void Start()
    {
        if (_player is null)
            throw new InvalidOperationException("Input has no player ref");
    }

    private void Update()
    {
        _player.Move(Input.GetAxis("Horizontal"));

        if (Input.GetKey(KeyCode.Space))
            _player.Jump();
    }
}
