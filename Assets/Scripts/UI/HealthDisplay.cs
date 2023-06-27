using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _healthDisplay;

    private void OnEnable()
    {
        _player.ChangingHealth += ChangeHealth;
    }

    private void OnDisable()
    {
        _player.ChangingHealth -= ChangeHealth;
    }

    private void ChangeHealth(int health)
    {
        _healthDisplay.text = health.ToString();
    }
}