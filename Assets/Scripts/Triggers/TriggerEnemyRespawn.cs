using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnemyRespawn : MonoBehaviour
{
    [SerializeField] private EnemyRespawn _enemyRespawn;
    [SerializeField] private UnityEvent _isPlayerBySandbags;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isPlayerBySandbags?.Invoke();
            gameObject.SetActive(false);
        }
    }
}