using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
public class PlayerCelebrateState : State
{
    public UnityAction Celebrate;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(AnimatorPlayerController.States.Celebrate);
        Celebrate?.Invoke();
    }
}