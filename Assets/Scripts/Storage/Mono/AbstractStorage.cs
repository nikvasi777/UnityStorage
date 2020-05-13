using UnityEngine;

namespace Storage.Mono
{
    public abstract class AbstractStorage<T> : MonoBehaviour, ISyncService
        where T : MonoBehaviour
    {
        private static T Instance;
    
        public static T GetInstance()
        {
            if (Instance != null)
            {
                return Instance;
            }
        
            Instance = (T) FindObjectOfType(typeof(T));
            if (Instance != null)
            {
                return Instance;
            }

            GameObject singleton = new GameObject
            {
                name = "S_" + typeof(T)
            };
            if (Application.isPlaying)
            {
                DontDestroyOnLoad(singleton);
            }
        
            return Instance = singleton.AddComponent<T>();
        }

        public void OnKeyValueUpdated(string key, object value)
        {
            //TODO: sync data with server
        }

        protected virtual void Start()
        {
            //TODO: sync data with server
        }

        protected virtual void OnApplicationPause(bool pauseStatus)
        {
            //TODO: sync data with server
        }
        
        protected virtual void OnApplicationQuit()
        {
            //TODO: sync data with server
        }
    }
}
