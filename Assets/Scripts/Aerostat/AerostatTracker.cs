using UnityEngine;

public class AerostatTracker : MonoBehaviour
{
    [SerializeField] private Aerostat _aerostat;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        Vector3 position = transform.position;
        position.x = _aerostat.transform.position.x + _xOffset;
        transform.position = position;        
    }

}
