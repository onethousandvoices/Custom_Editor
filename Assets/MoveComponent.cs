using System.Collections.Generic;
using UnityEngine;

namespace CustomEditor
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField, Range(0f, float.MaxValue)]
        private float _moveVelocity;
        [SerializeField]
        private float _maxVelocity;
        [SerializeField]
        private float _currentVelocity;
        [SerializeField]
        private float _jumpForce;
        [SerializeField]
        private List<int> _listInts;
        [SerializeField]
        private List<string> _listStrings;

    }
}