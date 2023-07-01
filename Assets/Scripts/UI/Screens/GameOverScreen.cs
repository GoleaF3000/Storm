using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : Screen
{
    private void Start()
    {      
        foreach (var element in _elementsForManage)
        {
            element.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _player.Died += Open;
    }

    private void OnDisable()
    {
        _player.Died -= Open;
    }
}