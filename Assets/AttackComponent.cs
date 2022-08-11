using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField, Range(1f, float.MaxValue)]
    private float _damage;
    [SerializeField, Range(1f, float.MaxValue)]
    private float _attackDelay;
    [SerializeField]
    private List<string> _animationKeys;
}
