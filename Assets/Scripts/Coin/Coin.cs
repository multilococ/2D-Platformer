using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Collected;

    public void Init(Vector3 spawnPointPosition) 
    {
        transform.position = spawnPointPosition;
    }

    public void Take()
    {
        Collected?.Invoke(this);
    }
}
