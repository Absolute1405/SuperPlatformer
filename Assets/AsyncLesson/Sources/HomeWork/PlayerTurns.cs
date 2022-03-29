using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class PlayerTurns : MonoBehaviour
    {
        [SerializeField] private Player player1;
        [SerializeField] private Player player2;
        [SerializeField] private int _winScore = 300;
        [SerializeField] private float _turnsDuration = 10f;
        [SerializeField] private Timer _timer;

        private void Start()
        {
            PlayInOrder();
        }

        public async void  PlayInOrder()
        {
            Player winner;

            while (true)
            {
                _timer.Setup(_turnsDuration);
                Debug.Log($"{player1.gameObject.name} turn");
                await player1.Play(_turnsDuration, _winScore);
                _timer.Stop();

                if (player1.Score >= _winScore)
                {
                    winner = player1;
                    break;
                }

                _timer.Setup(_turnsDuration);
                Debug.Log($"{player2.gameObject.name} turn");
                await player2.Play(_turnsDuration, _winScore);
                _timer.Stop();

                if (player2.Score >= _winScore)
                {
                    winner = player2;
                    break;
                }
            }

            OnFinish(winner);
        }

        private void OnFinish(Player player) 
        {
            Debug.Log($"{player.gameObject.name} won");
        }


    }
}

