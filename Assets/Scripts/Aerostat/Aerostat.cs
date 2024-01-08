using GameEvent;
using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AerostatMover))]
[RequireComponent(typeof(CollisionHandler))]
public class Aerostat : MonoBehaviour
{    
    [SerializeField] private TwoParamIntEvent ChangedHealth;
    [SerializeField] private ObjectPool _bulletPool;
    [SerializeField] private Counter _cannonballsCounter;

    private CollisionHandler _collisionHandler;
    private AerostatMover _aerostatMover;       
    private Health _health = new Health(100);

    public event Action GameOver;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _aerostatMover = GetComponent<AerostatMover>();        
        _collisionHandler.CollisionDetected += Collision;
        _health.ChandedHealth += OnChandedHealth;
        _health.Died += OnDied;
    }

    private void OnDestroy()
    {
        _collisionHandler.CollisionDetected -= Collision;
        _health.ChandedHealth -= OnChandedHealth;
        _health.Died -= OnDied;
    }

    public void Reset()
    {
        _aerostatMover.Reset();
        _health.Reset();        
    }

    private void OnDied()
    {
        GameOver?.Invoke();
    }

    private void OnChandedHealth() 
    {    
        ChangedHealth?.Invoke(_health.MaxValue, _health.Value);
    }

    private void Collision(IInteractable interactable)
    {
         if (interactable is Bullet)
        {
            var bullet = interactable as Bullet;

            _health.TakeDamage(bullet.Demage);                              
        }
        else if (interactable is CannonballsBox)
        {
            var box = interactable as CannonballsBox;

            _cannonballsCounter.Add(box.Quantity);
        }
        else if (interactable is Zeppelin || interactable is Ground)
        {
            _health.TakeDamage();            
        }
    }   
}
