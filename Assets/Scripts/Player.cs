using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private VictoryScreen _victoryScreen;

    private int _basicHealth;
    private Vector3 _basicPosition;
    private int _wallet = 0;
    private bool _isBase = false;
    private bool _isDead = false;       

    public UnityAction<int> ChangingHealth;
    public UnityAction<int> AddedReward;
    public UnityAction Died;

    public int Wallet => _wallet;
    public bool IsBase => _isBase;
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
        AddedReward?.Invoke(_wallet);
        ChangingHealth?.Invoke(_health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TriggerBase>(out TriggerBase triggerBase))
        {
            _isBase = true;
        }
    }

    private void OnDisable()
    {
        _gameOverScreen.ClosedPanel -= Restart;
        _victoryScreen.ClosedPanel -= Restart;
    }

    public void PutReward(int reward)
    {
        _wallet += reward;
        AddedReward?.Invoke(_wallet);
    }

    public void PayCoins(int price)
    {
        _wallet -= price;
        AddedReward?.Invoke(_wallet);
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
        _isBase = false;
        transform.position = _basicPosition;        
        ChangingHealth?.Invoke(_health);
    }
}