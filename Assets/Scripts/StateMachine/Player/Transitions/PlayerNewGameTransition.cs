using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Player))]
public class PlayerNewGameTransition : Transition
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private VictoryScreen _victoryScreen;

    private new void OnEnable()
    {
        base.OnEnable();
        _gameOverScreen.ClosedPanel += AllowTransit;
        _victoryScreen.ClosedPanel += AllowTransit;
    }

    private void OnDisable()
    {
        _gameOverScreen.ClosedPanel -= AllowTransit;
        _victoryScreen.ClosedPanel -= AllowTransit;
    }

    private void AllowTransit()
    {
        NeedTransit = true;
    }
}