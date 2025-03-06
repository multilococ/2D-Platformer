using System;
using UnityEngine;

public class Item : MonoBehaviour, ITakeable
{
    public event Action<Item> Collected;

    public void Init(Vector3 spawnPointPosition)
    {
        transform.position = spawnPointPosition;
    }

    public void Accept(ItemInteractor interactor)
    {
        Collected?.Invoke(this);
        Handle(interactor);
    }

    protected virtual void Handle(ItemInteractor interactor) 
    {
        Debug.Log("CoinCollected");   
    }
}
