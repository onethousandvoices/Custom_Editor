using UnityEngine;

namespace CustomEditor
{
    public class UnitManager : MonoBehaviour
    {
        [SerializeField]
        private BotComponent _bot1;
        [SerializeField]
        private BotComponent _bot2;
        [SerializeField]
        private BotComponent _bot3;

        [Space, SerializeField]
        private PlayerComponent _player;
        [SerializeField]
        private BotComponent[] _bots;
    }
}