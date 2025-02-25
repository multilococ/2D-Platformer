using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<CoinSpawnPoint> _spawnPoints;
    [SerializeField] private int _spawnDelay = 5;

    private List<CoinSpawnPoint> _emptySpawnPoints;

    private int _spawnCount = 100;

    private void Start()
    {
        StartCoroutine(SpawnCoinWithDelay());
    }

    private List<CoinSpawnPoint> GetEmptySpawnPoints()
    {
        List<CoinSpawnPoint> emptySpawnPoints = new List<CoinSpawnPoint>();

        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            if (_spawnPoints[i].HasCoin == false)
                emptySpawnPoints.Add(_spawnPoints[i]);
        }

        return emptySpawnPoints;
    }

    private IEnumerator SpawnCoinWithDelay()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnDelay);

        for (int i = 0; i < _spawnCount; i++)
        {
            _emptySpawnPoints = GetEmptySpawnPoints();

            for (int j = 0; j < _emptySpawnPoints.Count; j++)
            {
                _emptySpawnPoints[j].SpawnCoin();
                Debug.Log("Spawn Coin");
            }

            if (_emptySpawnPoints.Count == 0)
                i = 0;

            yield return waitForSeconds;
        }
    }
}
