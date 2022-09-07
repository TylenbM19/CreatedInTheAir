using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    private int _currentHealth;

    public static event UnityAction<int, int> OnDamage;

    public static event UnityAction Dying;

    public virtual void TakeDamage(int damage) 
    {
        _currentHealth -= damage;
        OnDamage?.Invoke(_currentHealth, _health);
    }
}
