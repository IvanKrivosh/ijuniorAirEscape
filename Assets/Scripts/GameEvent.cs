using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

namespace GameEvent
{
    [Serializable] public class TwoParamIntEvent : UnityEvent<int, int> { };

    [Serializable] public class IntEvent : UnityEvent<int> { };

    [Serializable] public class PositionEvent : UnityEvent<Vector3> { };
    
}