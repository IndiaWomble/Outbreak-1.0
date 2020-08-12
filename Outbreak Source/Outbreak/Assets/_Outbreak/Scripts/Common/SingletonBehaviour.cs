using UnityEngine;

namespace Outbreak
{
    public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
    {
        private static T _instance;

        public static T Instance { get => _instance; }

        protected virtual void Awake()
        {
            if(_instance == null)
            {
                _instance = GetComponent<T>();
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(GetComponent<T>());
            }
        }
    }
}