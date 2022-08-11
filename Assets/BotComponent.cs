using UnityEngine;

namespace CustomEditor
{
    public class BotComponent : MonoBehaviour
    {
        [SerializeField]
        private SideType _side;

        [SerializeField]
        private AiStateType _type;
        [SerializeField, Range(0f, 1000f)]
        private int _health;
        [SerializeField]
        private Vector3 _vector3;
    }
}