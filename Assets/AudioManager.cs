using System.Collections.Generic;
using UnityEngine;

namespace CustomEditor
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private List<AudioSourceData> _sources;
        [SerializeField]
        private List<AudioData> _clips;
        [SerializeField]
        private AudioSourceData _defaultSource;
        [SerializeField]
        private AudioData _defaultClip;
        [SerializeField]
        private SerializableClass _class;
    }

    [System.Serializable]
    public struct AudioSourceData
    {
        public AudioSource Source;
    }

    [System.Serializable]
    public struct AudioData
    {
        public string ID;
        public AudioSourceData Type;
        public AudioClip Clip;
    }

    [System.Serializable]
    public class SerializableClass
    {
        public int NonFloat;
        public float NonInt;
    }
}