using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Coins
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _coinsCount;

        private int _spawnDelay = 3;

        private void Start()
        {
            StartCoroutine(InstantiateCoin());
        }

        private IEnumerator InstantiateCoin()
        {
            var delay = new WaitForSeconds(_spawnDelay);
            
            for (int i = 0; i < _coinsCount; i++)
            {
                int randomPointIndex = Random.Range(0, _spawnPoints.Length);
                Instantiate(_prefab, _spawnPoints[randomPointIndex].transform.position, quaternion.identity);
                yield return delay;
            }
        }
    }
}