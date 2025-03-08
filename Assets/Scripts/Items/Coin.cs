using UnityEngine;

public class Coin : Item
{
    [SerializeField] private float _value = 1;

    public float Value => _value;

    protected override void Handle(ItemInteractor interactor)
    {
        interactor.ColletCoint(this);
    }
}
