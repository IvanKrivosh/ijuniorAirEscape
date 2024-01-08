using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AerostatMover : MonoBehaviour
{
    [Range(0.1f, 1f)]
    [SerializeField] private float _speed;
    [Range(0.1f, 10f)]
    [SerializeField] private float _upForce;

    private Rigidbody2D _rigidbody2D;
    private bool _isLifting;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isLifting)
            _rigidbody2D.velocity = new Vector2(_speed, _upForce);
    }

    public void OnAddedForce()
    {
        _isLifting = true;
    }

    public void OnRemovedForce()
    {
        _isLifting = false;
    }

    public void Reset()
    {
        transform.position = _startPosition;        
        _rigidbody2D.velocity = Vector2.zero;
    }

}
