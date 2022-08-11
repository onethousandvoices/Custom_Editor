using UnityEngine;

namespace CustomEditor
{
    public class UnitComponent : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rb;
        [SerializeField]
        private MoveComponent _move;
        [SerializeField]
        private AttackComponent _attack;
    }
}
