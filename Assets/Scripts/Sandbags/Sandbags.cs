using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sandbags : MonoBehaviour
{
    [SerializeField] private int _health;

    public UnityAction<int> SetMaxHealth;
    public UnityAction<int> ChangeHealth;

    private void Start()
    {
        SetMaxHealth?.Invoke(_health);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        ChangeHealth?.Invoke(_health);

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}