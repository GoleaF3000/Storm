using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
public class PlayerDeadState : State
{    
    private Animator _animator;    

    private void Awake()
    {
        _animator = GetComponent<Animator>();       
    }

    private void OnEnable()
    {
        _animator.Play(AnimatorPlayerController.States.Die);
    }
}