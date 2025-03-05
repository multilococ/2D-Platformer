using UnityEngine;
using UnityEngine.Pool;

public class ItemCreater : MonoBehaviour
{
    [SerializeField] private Item _prefab;

    private ObjectPool<Item> _pool;

    private int _poolCapacity = 10;
    private int _poolMaxSize = 10;

    private void Awake()
    {
        _pool = CreatePool();
    }

    public Item GetPrefab(Vector3 spawnPointPosition)
    {
        Item item = _pool.Get();

        item.Init(spawnPointPosition);
        item.Collected += RelesePrefab;
        return item;
    }

    private ObjectPool<Item> CreatePool()
    {
        return new ObjectPool<Item>(
            createFunc: () => Instantiate(_prefab),
            actionOnRelease: (item) => item.gameObject.SetActive(false),
            actionOnGet: (item) => SetPrefabActive(item),
            actionOnDestroy: (item) => Destroy(item.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void SetPrefabActive(Item item)
    {
        item.gameObject.SetActive(true);
    }

    private void RelesePrefab(Item item)
    {
        item.Collected -= RelesePrefab;
        _pool.Release(item);
    }
}
