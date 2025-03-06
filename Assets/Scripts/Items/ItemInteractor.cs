using UnityEngine;

public class ItemInteractor  : MonoBehaviour
{
    [SerializeField] private ItemInteractor _interactor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITakeable takeable))
        { 
            takeable.Accept(_interactor);
        }
    }
}