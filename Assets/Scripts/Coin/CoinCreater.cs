using UnityEngine;
using UnityEngine.Pool;

public class CoinCreater : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    private ObjectPool<Coin> _pool;

    private int _poolCapacity = 10;
    private int _poolMaxSize = 10;

    private void Awake()
    {
        _pool = CreatePool();
    }

    public Coin GetPrefab(Vector3 spawnPointPosition) 
    {
        Coin coin = _pool.Get();

        coin.Init(spawnPointPosition);
        coin.Collected += RelesePrefab;
        return coin;
    }

    private ObjectPool<Coin> CreatePool()
    {
        return new ObjectPool<Coin>(
            createFunc: () => Instantiate(_prefab),
            actionOnRelease: (coin) => coin.gameObject.SetActive(false),
            actionOnGet: (coin) => SetPrefabActive(coin),
            actionOnDestroy: (coin) => Destroy(coin.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize) ;
    }

    private void SetPrefabActive(Coin coin) 
    {
        coin.gameObject.SetActive(true);
    }

    private void RelesePrefab(Coin coin) 
    {
        coin.Collected -= RelesePrefab;
        _pool.Release(coin);
    }
}
