using System.Collections;
using UnityEngine;

public class Zeppelin : StoredObject, IInteractable
{
    [Range(1f, 10f)]
    [SerializeField] private float _shootingTime;    

    private SpawnPoint _spawnPoint;
    private WaitForSeconds _waitTime;    

    public ObjectPool BulletPool { get; private set; }

    private void Awake()
    {
        _spawnPoint = GetComponent<SpawnPoint>();
        _waitTime = new WaitForSeconds(_shootingTime);        
    }

    private void OnEnable()
    {
        int delayShotting = 1;

        Invoke(nameof(Shoot), delayShotting);
    }

    public void Init(ObjectPool objectPool)
    {
        BulletPool = objectPool;
    }

    private void Shoot()
    {
        StartCoroutine(GenerateBullet());
    }

    private IEnumerator GenerateBullet()
    {
        while (enabled)
        {
            Bullet bullet = BulletPool.GetInstance(_spawnPoint.transform.position).GetComponent<Bullet>();            
            yield return _waitTime;
        }
    }
}
