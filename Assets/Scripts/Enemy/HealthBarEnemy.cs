using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : HealthBarSetter
{
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.SetMaxHealth += SetMaxValue;
        _enemy.ChangeHealth += ChangeValue;
    }

    private void Update()
    {
        _slider.transform.position = Camera.main.WorldToScreenPoint(_enemy.transform.position + _ofset);
    }

    private void OnDisable()
    {
        _enemy.SetMaxHealth -= SetMaxValue;
        _enemy.ChangeHealth -= ChangeValue;
    }
}
