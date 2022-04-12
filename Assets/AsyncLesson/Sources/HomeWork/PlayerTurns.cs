using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

namespace Game
{
    public class PlayerTurns : MonoBehaviour
    {
        [SerializeField] private Player player1;
        [SerializeField] private Player player2;
        [SerializeField] private int _winScore = 300;
        [SerializeField] private int _turnsDuration = 10;
        [SerializeField] private Timer _timer;
        [SerializeField] private Ready _readyButton;

        private bool _gameFinished;

        private void Start()
        {
            PlayInOrder();
        }

        public async void  PlayInOrder()
        {
            player1.Won += OnFinish;
            player2.Won += OnFinish;

            while (_gameFinished == false)
            {
                await PlayOnPlayer(player1);

                if (_gameFinished)
                    break;

                await PlayOnPlayer(player2);
            }
        }

        private async Task PlayOnPlayer(Player player)
        {
            await _readyButton.WaitClick();

            Debug.Log($"{player.gameObject.name} turn");

            player.StartTurn(_winScore);
            await _timer.WaitForSeconds(_turnsDuration);
            player.StopTurn();
        }

        private void OnFinish(Player player)
        {
            _gameFinished = true;
            _timer.StopTimer();
            player.StopTurn();
            Debug.Log($"{player.gameObject.name} won");
        }


    }
}

