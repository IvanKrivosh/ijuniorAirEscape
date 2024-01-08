using System;
using UnityEngine;

[Serializable]
public class DamageIndicatorItem
{
    [SerializeField] private Fire _fire;
    [SerializeField] private int _health;

    public Fire Fire => _fire;
    public int Health => _health;
}