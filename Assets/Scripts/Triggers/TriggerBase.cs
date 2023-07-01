using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerBase : MonoBehaviour
{
    [SerializeField] private VictoryScreen _victoryScreen;

    private BoxCollider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();       
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