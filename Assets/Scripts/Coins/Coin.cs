﻿using UnityEngine;

namespace Coins
{
    public class Coin : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            Destroy(gameObject);
        }
    }
}