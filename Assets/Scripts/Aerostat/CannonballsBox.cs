using UnityEngine;

public class CannonballsBox : StoredObject, IInteractable
{
    [SerializeField] private int _quantity;

    public int Quantity => _quantity;
}
