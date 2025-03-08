using UnityEngine;

public class ItemInteractor  : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Wallet _wallet;

    private ItemInteractor _interactor;

    private void Awake()
    {
        _interactor = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITakeable takeable))
        { 
            takeable.Accept(_interactor);
        }
    }

    public void ColletCoint(Coin coin) 
    {
        _wallet.Add(coin.Value);
    }

    public void ReceiveTreatment(MedKit medKit) 
    {
        _health.ReceiveTreatment(medKit.RecoverableHealth);
    }

}