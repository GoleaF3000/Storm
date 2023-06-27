using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerDefenceTransition : Transition
{
    private Sandbags _sandbags;

    public Sandbags Sandbags => _sandbags;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Sandbags>(out Sandbags sandbags))
        {
            _sandbags = sandbags;
            NeedTransit = true;
        }
    }
}