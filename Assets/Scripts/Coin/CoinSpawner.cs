using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<CoinSpawnPoint> _spawnPoints;
    
    [SerializeField] private int _spawnDelay = 5;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        if (_spawnPoints.Count < 1)
        {
            throw new InvalidOperationException();
        }

        _waitForSeconds = new WaitForSeconds(_spawnDelay);
        SpawnAllCoins();
    }

    private void OnEnable()
    {
        foreach (CoinSpawnPoint spawnPoint in _spawnPoints)
            spawnPoint.Devastated += DetectEmptySpawnPoint;
    }

    private void OnDisable()
    {
        foreach(CoinSpawnPoint spawnPoint in _spawnPoints)
            spawnPoint.Devastated -= DetectEmptySpawnPoint;
    }

    private void DetectEmptySpawnPoint(CoinSpawnPoint spawnPoint)
    {
        StartCoroutine(SpawnCoinWithDelay(spawnPoint));
    }
 
    private void SpawnAllCoins()
    {
        foreach (CoinSpawnPoint spawnPoint in _spawnPoints)
            spawnPoint.Spawn();
    }

    private IEnumerator SpawnCoinWithDelay(CoinSpawnPoint spawnPoint)
    {
        yield return _waitForSeconds;

        Debug.Log("SpawnCoin in : " + spawnPoint.name);
        spawnPoint.Spawn();
    }
}