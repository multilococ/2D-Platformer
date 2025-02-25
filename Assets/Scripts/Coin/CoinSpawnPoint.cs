using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    [SerializeField] private CoinPool _coinPool;
    
    private Coin _coin;

    private bool _hasCoin;

    public bool HasCoin => _hasCoin;

    private void Awake()
    {
        _coin = null;
        _hasCoin = false;
    }

    public void SpawnCoin() 
    {
        _coin = _coinPool.GetCoin(transform);
        _hasCoin = true;
        _coin.Collected += CoinCollected;
    }

    private void CoinCollected(Coin coin)
    {
        coin.Collected -= CoinCollected;
        _hasCoin = false;
        _coin = null;
    }
}
