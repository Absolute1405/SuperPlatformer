using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class PlayerTurns : MonoBehaviour
    {
        [SerializeField] private Player player1;
        [SerializeField] private Player player2;
        [SerializeField] private int _winScore;
        [SerializeField] private float _turnsDyreshen;

        public async void  PlayInOrder()
        {
            while (true)
            {
                player1.Play(_turnsDyreshen);
                if (player1.Score == _winScore)
                {
                    OnFinish(player1);
                }
                await
            }
            
        }
        private void OnFinish(Player player) 
        {
            
        }
    }
}

