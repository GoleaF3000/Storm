using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButton : SkillButton
{
    [SerializeField] private int _countHealPoints;

    public override void StartAction()
    {
        if (TryPayAction())
        {
            enabled = true;
            _player.TakeHealthPoints(_countHealPoints);
        }
    }
}