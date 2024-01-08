using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class ZeppelinGenerator : MonoBehaviour
{    
    [Range(1f, 10f)]
    [SerializeField] private float _delayTime;
    [SerializeField] private ObjectPool _bulletPool;

    private List<SpawnPoint> _points;
    private WaitForSeconds _waitTime;
    private ObjectPool _pool;

    private void Awake()
    {
        _pool = GetComponent<ObjectPool>();
        _points = GetComponentsInChildren<SpawnPoint>().ToList();
        _waitTime = new WaitForSeconds(_delayTime);
    }

    private void Start()
    {
        StartCoroutine(GenerateObject());
    }

    protected IEnumerator GenerateObject()
    {
        while (enabled)
        {
            var zeppelin = _pool.GetInstance().GetComponent<Zeppelin>();
            int indexPoint = Random.Range(0, _points.Count);
            zeppelin.transform.position = _points[indexPoint].transform.position;            

            if (zeppelin.BulletPool == null)
                zeppelin.Init(_bulletPool);

            yield return _waitTime;
        }
    }
}
