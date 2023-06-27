using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerDeadState : State
{    
    private Animator _animator;    

    private void Awake()
    {
        _animator = GetComponent<Animator>();       
    }

    private void OnEnable()
    {
        _animator.Play("Die");
    }
}