using System;
using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour
{
    private Item _item;

    public event Action<ItemSpawnPoint> Devastated;

    public bool HasItem { get; private set; }

    private void Awake()
    {
        _item = null;
        HasItem = false;
    }

    public void SetItem(Item item)
    {
        _item = item;
        HasItem = true;
        _item.Collected += Devastate;
    }

    private void Devastate(Item item)
    {
        item.Collected -= Devastate;
        HasItem = false;
        _item = null;
        Devastated?.Invoke(this);
    }
}
