using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateOfFireButton : SkillButton
{   
    [SerializeField] private float _delayOfFire;

    public float Delay => _delayOfFire;

    public override void StartAction()
    {
        enabled = true;
    }
}