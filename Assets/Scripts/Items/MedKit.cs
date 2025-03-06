using UnityEngine;

public class MedKit : Item
{
    [SerializeField] private float _recoverableHealth = 10;

    protected override void Handle(ItemInteractor interactor)
    {
        if (interactor.TryGetComponent(out IHealingable healingable))
            healingable.ReceiveTreatment(_recoverableHealth);
    }
}
