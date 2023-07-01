using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandbagsController : MonoBehaviour
{
    [SerializeField] private Sandbags _sandbags;
    [SerializeField] private TriggerEnemyRespawn _triggerEnemy;
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private GameOverScreen _GameOverScreen;

    private void OnEnable()
    {
        _victoryScreen.ClosedPanel += OnObjects;
        _GameOverScreen.ClosedPanel += OnObjects;
    }

    private void OnDisable()
    {
        _victoryScreen.ClosedPanel -= OnObjects;
        _GameOverScreen.ClosedPanel -= OnObjects;
    }

    private void OnObjects()
    {
        _sandbags.gameObject.SetActive(true);
        _sandbags.Restart();
        _triggerEnemy.gameObject.SetActive(true);
    }
}