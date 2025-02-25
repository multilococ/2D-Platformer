using UnityEngine;
using UnityEngine.Pool;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    private ObjectPool<Coin> _pool;

    private int _poolCapacity = 10;
    private int _poolMaxSize = 10;

    private void Awake()
    {
        _pool = CreatePool();
    }

    public Coin GetCoin(Transform spawnPoint) 
    {
        Coin coin = _pool.Get();

        coin.Init(spawnPoint);
        coin.Collected += ReleseCoin;
        return coin;
    }

    private ObjectPool<Coin> CreatePool()
    {
        return new ObjectPool<Coin>(
            createFunc: () => Instantiate(_prefab),
            actionOnRelease: (coin) => coin.gameObject.SetActive(false),
            actionOnGet: (coin) => SetCoinActive(coin),
            actionOnDestroy: (coin) => Destroy(coin.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize) ;
    }

    private void SetCoinActive(Coin coin) 
    {
        coin.gameObject.SetActive(true);
    }

    private void ReleseCoin(Coin coin) 
    {
        coin.Collected -= ReleseCoin;
        _pool.Release(coin);
    }
}
