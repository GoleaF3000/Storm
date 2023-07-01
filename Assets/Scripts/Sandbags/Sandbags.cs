using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sandbags : MonoBehaviour
{
    [SerializeField] private int _health;

    public UnityAction<int> SetMaxHealth;
    public UnityAction<int> ChangeHealth;

    private int _baseHealth;

    private void Awake()
    {
        _baseHealth = _health;
        SetMaxHealth?.Invoke(_baseHealth);
    }

    public void Restart()
    {
        _health = _baseHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        ChangeHealth?.Invoke(_health);

        if (_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}