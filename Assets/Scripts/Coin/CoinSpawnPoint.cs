using System;
using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    private Coin _coin;

    public event Action<CoinSpawnPoint> Devastated;

    public bool HasCoin { get; private set; }

    private void Awake()
    {
        _coin = null;
        HasCoin = false;
    }

    public void SetCoin(Coin coin) 
    {
        _coin = coin;
        HasCoin = true;
        _coin.Collected += Devastate;
    }

    private void Devastate(Coin coin)
    {
        coin.Collected -= Devastate;
        HasCoin = false;
        _coin = null;
        Devastated?.Invoke(this);
    }
}
