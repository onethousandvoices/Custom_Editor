using UnityEngine;

namespace CustomEditor
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _menu;
        [SerializeField]
        private RectTransform _settings;
        [SerializeField]
        private RectTransform _inventory;
        [SerializeField]
        private RectTransform _dialogue;
        [SerializeField]
        private RectTransform _battle;
        [SerializeField]
        private Color _startColor;
        [SerializeField]
        private Color _endColor;
    }
}