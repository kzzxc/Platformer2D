using Unity.Mathematics;
using UnityEngine;


namespace Coins
{
    public class CoinsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Coin _prefab; 
        
        private int _coinsCount;

        private void Start()
        {
            _coinsCount = _spawnPoints.Length;
            SpawnCoins();
        }

        private void SpawnCoins()
        {
            for (int i = 0; i < _coinsCount; i++)
            {
                Instantiate(_prefab, _spawnPoints[i].transform.position, quaternion.identity);
            }
        }
    }
}