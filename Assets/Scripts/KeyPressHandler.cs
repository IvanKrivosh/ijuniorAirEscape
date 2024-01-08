using UnityEngine;
using UnityEngine.Events;

public class KeyPressHandler : MonoBehaviour
{
    private const KeyCode SpaceCode = KeyCode.Space;
    private const KeyCode ShootCode = KeyCode.D;

    [SerializeField] private UnityEvent _pressedDownSpace;
    [SerializeField] private UnityEvent _pressedUpSpace;
    [SerializeField] private UnityEvent _pressedShoot;

    private void Update()
    {
        if (Input.GetKeyDown(SpaceCode))
            _pressedDownSpace.Invoke();
        else if (Input.GetKeyUp(SpaceCode))
            _pressedUpSpace.Invoke();

        if (Input.GetKeyDown(ShootCode))
            _pressedShoot.Invoke();
    }
}
