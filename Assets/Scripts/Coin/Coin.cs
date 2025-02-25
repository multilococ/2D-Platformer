using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Collected;

    public void Init(Transform spawnPoint) 
    {
        transform.position = spawnPoint.position;
    }

    public void Take()
    {
        Collected?.Invoke(this);
    }
}
