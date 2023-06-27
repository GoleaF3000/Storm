using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : Screen
{
    private PlayerCelebrateState _playerCelebrate;

    private void Awake()
    {
        _playerCelebrate = FindObjectOfType<PlayerCelebrateState>();
    }

    private void Start()
    {   
        foreach (var element in _elements)
        {
            element.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _playerCelebrate.Celebrate += Open;
    }

    private void OnDisable()
    {
        _playerCelebrate.Celebrate -= Open;
    }
}