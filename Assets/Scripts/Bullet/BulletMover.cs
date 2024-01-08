using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMover : MonoBehaviour
{    
    [Range(5f, 10f)]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private bool _toLeftDirection = true;

    private int _direction;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0;
        _direction = _toLeftDirection ? -1 : 1;        
    }

    private void OnEnable()
    {
        _rigidbody2D.velocity = new Vector2(_speed * _direction, 0);
    }
}
