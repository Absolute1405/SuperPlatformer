using System;
using System.Collections;
using System.Collections.Generic;
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

        private void Start()
        {
            PlayInOrder();
        }

        public async void  PlayInOrder()
        {
            Player winner;

            while (true)
            {
                var Winer1 =await PlayOnPlayer(player1);
                if (Winer1)
                {
                    winner = player1;
                    break;
                }

                var Winer2 = await PlayOnPlayer(player2);

                if (Winer2)
                {
                    winner = player2;
                    break;
                }
            }

            OnFinish(winner);
        }
        private async Task<bool> PlayOnPlayer(Player player)
        {
            await _readyButton.WaitClick();

            Debug.Log($"{player.gameObject.name} turn");
            var Play = player.Play(_winScore);
            var timer = _timer.WaitForSeconds(_turnsDuration);

            await Task.WhenAny(Play, timer);

            return player.Score >= _winScore;
        }

        private void OnFinish(Player player) 
        {
            Debug.Log($"{player.gameObject.name} won");
        }


    }
}

