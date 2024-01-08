using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(Counter))]
public class Сannon : MonoBehaviour
{
    private ObjectPool _pool;
    private Counter _cannonballsCounter;

    private void Awake()
    {
        _pool = GetComponent<ObjectPool>();
        _cannonballsCounter = GetComponent<Counter>();
    }

    public void Shoot()
    {
        if (_cannonballsCounter.Count > 0)
        {
            _cannonballsCounter.Dicriment();
            _pool.GetInstance(transform.position).GetComponent<Сannonball>();
        }
    }
}
