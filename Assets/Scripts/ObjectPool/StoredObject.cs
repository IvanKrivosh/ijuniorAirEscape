using System;
using UnityEngine;

public class StoredObject: MonoBehaviour
{
    public event Action<StoredObject, bool> Collided;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        bool zone = other.TryGetComponent<RemoveZone>(out RemoveZone remoteZone);

        Collided?.Invoke(this, !zone);
    }
}