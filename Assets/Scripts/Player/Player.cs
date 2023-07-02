using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(PlayerTrigger))]
[RequireComponent (typeof (PlayerWallet))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private VictoryScreen _victoryScreen;

    private int _basicHealth;
    private Vector3 _basicPosition;
    private PlayerTrigger _trigger;
    private bool _isDead = false;       

    public event UnityAction<int> ChangingHealth;    
    public event UnityAction Died;    
    
    public bool IsDead => _isDead;
    public float SpeedPersonage => _speed;

    private void OnEnable()
    {
        _gameOverScreen.ClosedPanel += Restart;
        _victoryScreen.ClosedPanel += Restart;
    }

    private void Start()
    {
        _basicPosition = new Vector3(transform.position.x, transform.position.y, 
            transform.position.z);
        _basicHealth = _health;         
        ChangingHealth?.Invoke(_health);
        _trigger = GetComponent<PlayerTrigger>();
    }

    private void OnDisable()
    {
        _gameOverScreen.ClosedPanel -= Restart;
        _victoryScreen.ClosedPanel -= Restart;
    }   
    
    public void TakeHealthPoints(int healthPoints)
    {
        _health += healthPoints;
        ChangingHealth?.Invoke(_health);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        ChangingHealth?.Invoke(_health);

        if (_health <= 0)
        {
            _health = 0;
            _isDead = true;
            Died?.Invoke();
        }
    }

    public void Restart()
    {
        _health = _basicHealth;
        _isDead = false;
        _trigger.Restart();
        transform.position = _basicPosition;        
        ChangingHealth?.Invoke(_health);
    }
}