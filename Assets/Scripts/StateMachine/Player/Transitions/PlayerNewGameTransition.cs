using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNewGameTransition : Transition
{
    private GameOverScreen _endScreen;
    private VictoryScreen _victoryScreen;

    private void Awake()
    {
        _endScreen = FindObjectOfType<GameOverScreen>();
        _victoryScreen = FindObjectOfType<VictoryScreen>();
    }

    private new void OnEnable()
    {
        NeedTransit = false;
        _endScreen.ClosedPanel += AllowTransit;
        _victoryScreen.ClosedPanel += AllowTransit;
    }

    private void OnDisable()
    {
        _endScreen.ClosedPanel -= AllowTransit;
        _victoryScreen.ClosedPanel -= AllowTransit;
    }

    private void AllowTransit()
    {
        NeedTransit = true;
    }
}