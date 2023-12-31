using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    public int Damage => _damage;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {           
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
        else if (collision.TryGetComponent<DestroyerBullets>(out DestroyerBullets destroyerBullets))
        {           
            Destroy(gameObject);
        }
    }
}