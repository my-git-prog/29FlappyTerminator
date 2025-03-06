using UnityEngine;

public class Character : Spawnable, IDamagable, IInteractable
{
    [SerializeField] protected Health Health;

    public void TakeDamage(int damage)
    {
        Health.TakeDamage(damage);
    }
}
