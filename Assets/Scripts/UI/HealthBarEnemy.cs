using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : Bar
{
    [SerializeField] private Vector3 _offset;

    private void OnEnable()
    {
        Enemy.OnDamage += OnValueChanged;
    }

    private void OnDisable()
    {
        Enemy.OnDamage -= OnValueChanged;
    }

    private void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + _offset);
    }


    public override void OnValueChanged(int value, int maxValue)
    {
        Slider.gameObject.SetActive(value < maxValue);
        base.OnValueChanged(value, maxValue);
    }
}
