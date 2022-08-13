using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    public event UnityAction Dying;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <=0)
        {
            Destroy(gameObject);
        }
    }
}
