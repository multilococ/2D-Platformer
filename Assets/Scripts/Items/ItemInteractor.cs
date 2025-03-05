using UnityEngine;

public class ItemInteractor  : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITakeable takeable))
        { 
            takeable.Take();
        }
    }
}