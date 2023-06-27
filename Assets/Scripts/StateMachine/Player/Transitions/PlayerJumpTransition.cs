using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerJumpTransition : Transition
{
    private PlayerDefenceTransition _defenceTransition;

    private void Awake()
    {
        _defenceTransition = GetComponent<PlayerDefenceTransition>();
    }

    private void FixedUpdate()
    {
        if (GameObject.FindObjectOfType<Enemy>() == false)
        {
            NeedTransit = true;            
        }
    }
}