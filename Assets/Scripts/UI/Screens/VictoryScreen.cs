using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : Screen
{
    [SerializeField] private PlayerCelebrateState _playerCelebrate;

    private void Start()
    {
        foreach (var element in _elementsForManage)
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