using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBase : MonoBehaviour
{
    private BoxCollider2D _collider;
    private VictoryScreen _victoryScreen;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _victoryScreen = FindObjectOfType<VictoryScreen>();
    }

    private void OnEnable()
    {
        _victoryScreen.ClosedPanel += OnCollider;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _collider.enabled = false;
        }
    }

    private void OnDisable()
    {
        _victoryScreen.ClosedPanel -= OnCollider;
    }

    private void OnCollider()
    {
        _collider.enabled = true;
    }
}