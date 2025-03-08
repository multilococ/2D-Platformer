using UnityEngine;

public class MedKit : Item
{
    [SerializeField] private float _recoverableHealth = 10;

    public float RecoverableHealth => _recoverableHealth;
    
    protected override void Handle(ItemInteractor interactor)
    {
        interactor.ReceiveTreatment(this);
    }
}
