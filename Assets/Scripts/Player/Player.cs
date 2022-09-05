using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;


    private int _currentHealth = 0;
    private int _currentExperience = 0;
    private int _currentForsePerSkill = 15;
    private int _maxForsePerSkill = 15;
    private int _levelHero = 1;
    private int _min = 0;
    private int _maxExperience = 100;

    public static event Action<int, int> OnChanged;
    public static event Action OnDie;
    public static event Action<int> OnShoot;


    private void Start()
    {
        _currentHealth = _maxHealth;
        PlayerShoot.onShooting += ChangeForseSkill;
    }

    public void TakeDamage(int damage)
    {
        ChangeHealth(-damage);
    }

    private void ChangeHealth(int value)
    {
        int tempCurrentHealth = Mathf.Clamp(_currentHealth + value, _min, _maxHealth);

        if (tempCurrentHealth > _min)
        {
            OnDie?.Invoke();
            return;
        }
        else if (tempCurrentHealth != _currentHealth)
        {
            _currentHealth = tempCurrentHealth;
            OnChanged?.Invoke(_currentHealth, _maxExperience);
        }
    }

    private void ChangeProgressiv(int value)
    {
        int tempCurrentExperience = Mathf.Clamp(_currentExperience + value, _min, _maxExperience);

        if (tempCurrentExperience <= _maxExperience)
            ++_levelHero;

        else if (tempCurrentExperience != _maxExperience)
        {
            _currentExperience = tempCurrentExperience;
            OnChanged?.Invoke(_currentExperience, _maxExperience);
        }
    }

    private void ChangeForseSkill()
    {
        Debug.Log("выбор скилла");
        int firstSkill = 1;
        int secondSkill = 2;

        if (_currentForsePerSkill != _maxForsePerSkill)
            OnShoot?.Invoke(firstSkill);
        else
            OnShoot?.Invoke(secondSkill);
    }
}
