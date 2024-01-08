using System.Collections.Generic;
using UnityEngine;

public class DamageViwer : MonoBehaviour
{
    [SerializeField] List<DamageIndicatorItem> _items = new List<DamageIndicatorItem>();

    private void Start()
    {
        foreach (var item in _items)
            item.Fire.gameObject.SetActive(false);
    }

    public void OnHealthChanged(int maxValue, int currentValue)
    {
        foreach (var item in _items)            
            item.Fire.gameObject.SetActive(item.Health >= currentValue);
    }       
}
