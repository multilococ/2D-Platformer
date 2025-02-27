using System;
using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    [SerializeField] private CoinCreater _coinCreater;

    private Coin _coin;

    public event Action<CoinSpawnPoint> Devastated;

    public bool HasCoin { get; private set; }

    private void Awake()
    {
        _coin = null;
        HasCoin = false;
    }

    public void Spawn()
    {
        _coin = _coinCreater.GetPrefab(transform);
        HasCoin = true;
        _coin.Collected += Collect;
    }

    private void Collect(Coin coin)
    {
        coin.Collected -= Collect;
        HasCoin = false;
        _coin = null;
        Devastated?.Invoke(this);
    }
}
