using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<ItemSpawnPoint> _spawnPoints;

    [SerializeField] private int _spawnDelay = 5;

    [SerializeField] private ItemCreater _creater;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        if (_spawnPoints.Count < 1)
        {
            throw new InvalidOperationException();
        }

        _waitForSeconds = new WaitForSeconds(_spawnDelay);
        SpawnAllItems();
    }

    private void OnEnable()
    {
        foreach (ItemSpawnPoint spawnPoint in _spawnPoints)
            spawnPoint.Devastated += DetectEmptySpawnPoint;
    }

    private void OnDisable()
    {
        foreach (ItemSpawnPoint spawnPoint in _spawnPoints)
            spawnPoint.Devastated -= DetectEmptySpawnPoint;
    }

    private void DetectEmptySpawnPoint(ItemSpawnPoint spawnPoint)
    {
        StartCoroutine(SpawnItemWithDelay(spawnPoint));
    }

    private void SpawnAllItems()
    {
        foreach (ItemSpawnPoint spawnPoint in _spawnPoints)
            spawnPoint.SetItem(_creater.GetPrefab(spawnPoint.transform.position));
    }

    private IEnumerator SpawnItemWithDelay(ItemSpawnPoint spawnPoint)
    {
        yield return _waitForSeconds;

        Debug.Log("SpawnItem in : " + spawnPoint.name);
        spawnPoint.SetItem(_creater.GetPrefab(spawnPoint.transform.position));
    }
}
