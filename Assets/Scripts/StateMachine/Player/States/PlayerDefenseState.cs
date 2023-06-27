using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerDefenseState : State
{
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private Transform _shootpoint;

    public UnityAction Defensive;
    public UnityAction Undefensive;

    private float _delay;
    private Animator _animator;

    private void Awake()
    {
        _delay = _currentWeapon.Delay;
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play("Fire");
        Defensive?.Invoke();
    }

    private void Update()
    {
        _currentWeapon.Shooting(ref _delay);
    }

    private void OnDisable()
    {
        Undefensive?.Invoke();
    }
}