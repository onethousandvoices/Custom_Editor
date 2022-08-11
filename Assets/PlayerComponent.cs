using UnityEngine;

namespace CustomEditor
{
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField]
        private SideType _side;
        [SerializeField, Range(0f, int.MaxValue)]
        private int _health;
        [SerializeField, Range(0f, int.MaxValue)]
        private int _mana;
        [SerializeField, Range(0f, int.MaxValue)]
        private int _stamina;
        [SerializeField]
        private Bounds _bounds;
        [SerializeField]
        private Vector2Int _vector2;
        [SerializeField]
        private bool _isBool;

        [SerializeField]
        private EquipmentComponent _weapon;
    }
}