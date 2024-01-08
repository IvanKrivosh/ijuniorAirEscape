using System;
using UnityEngine;

public class Bullet : StoredObject, IInteractable
{
    [Range(1, 10)]
    [SerializeField] private int _demage;

    public int Demage => _demage;
}
