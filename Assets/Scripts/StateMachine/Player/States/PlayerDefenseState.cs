using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
public class PlayerDefenseState : State
{
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private Transform _shootpoint;

    public event UnityAction Defensive;
    public event UnityAction Undefensive;

    private float _delay;
    private Animator _animator;

    private void Awake()
    {
        _delay = _currentWeapon.Delay;
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(AnimatorPlayerController.States.Fire);
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