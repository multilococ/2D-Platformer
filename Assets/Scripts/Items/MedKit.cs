using UnityEngine;

public class MedKit : Item
{
    [SerializeField] private float _recoverableHealth = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.TryGetComponent(out IHealingable healingable))
        {
            healingable.ReceiveTreatment(_recoverableHealth);
        }
    }
}
