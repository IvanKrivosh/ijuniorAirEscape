using GameEvent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private StoredObject _templates;
    [SerializeField] private PositionEvent _putObject;

    private Queue<StoredObject> _queue;
    private List<StoredObject> _objects;

    private void Awake()
    {
        _queue = new Queue<StoredObject>();
        _objects = new List<StoredObject>();
    }

    private void OnDestroy()
    {
        foreach (StoredObject item in _objects)
            item.Collided -= OnCollided;
    }

    public void Reset()
    {
        foreach (StoredObject item in _objects)
            PutObject(item, false);
    }

    public void OnPutObject(Vector3 positon)
    {
        GetInstance(positon);
    }

    public StoredObject GetInstance(Vector3? positon = null)
    {
        StoredObject instance = _queue.Count == 0 ? GenerateNewInstance() : _queue.Dequeue();

        if (positon.HasValue)
            instance.transform.position = positon.Value;

        instance.gameObject.SetActive(true);

        return instance;
    }

    public void PutObject(StoredObject storedObject, bool needNotify = true)
    {
        if (needNotify)
            _putObject.Invoke(storedObject.transform.position);

        storedObject.gameObject.SetActive(false);
        _queue.Enqueue(storedObject);
    }

    private StoredObject GenerateNewInstance()
    {
        StoredObject instance = Instantiate(_templates, null);
        instance.Collided += OnCollided;
        _objects.Add(instance);
        return instance;
    }

    private void OnCollided(StoredObject storedObject, bool needNotify)
    {
        PutObject(storedObject, needNotify);
    }    
}
