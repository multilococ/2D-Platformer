using System;
using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    [SerializeField] private CoinPool _coinPool;
    
    private Coin _coin;
    public bool HasCoin { private set; get; }

    public event Action<CoinSpawnPoint> Devastated;

    private void Awake()
    {
        _coin = null;
        HasCoin = false;
    }

    public void SpawnCoin() 
    {
        _coin = _coinPool.GetCoin(transform);
        HasCoin = true;
        _coin.Collected += CoinCollected;
    }

    private void CoinCollected(Coin coin)
    {
        coin.Collected -= CoinCollected;
        HasCoin = false;
        _coin = null;
        Devastated?.Invoke(this);
    }
}
