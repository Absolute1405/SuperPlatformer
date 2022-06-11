using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AppleGame
{
    public class ApplePool
    {
        private List<Apple> _apples;
        public ApplePool(Apple[] apples)
        {
            _apples = new List<Apple>(apples);
        }

        public Apple Pull()
        {
            foreach (var apple in _apples)
            {
                if (apple.Active == false)
                {
                    apple.SetActive(true);
                    return apple;
                }
                
            }
            throw new InvalidOperationException("not apple in pull");
        }
        public void Push(Apple apple)
        {
            apple.SetActive(false);
        }
    }
}
