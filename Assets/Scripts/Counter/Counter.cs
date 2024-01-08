using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField] private int _defaultQuantity;

    private int _count = 0;

    public event Action<int> Changed;

    public int Count => _count;

    public void Incriment()
    {
        Add(1);
    }

    public void Add(int count)
    {
        _count += count;
        ChangedCount();
    }

    public void Dicriment()
    {
        _count--;
        ChangedCount();
    }

    public virtual void Reset()
    {
        _count = _defaultQuantity;
        ChangedCount();
    }

    private void ChangedCount()
    {
        Changed?.Invoke(_count);
    }
}
