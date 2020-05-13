using System;
using Storage.Base;
using Storage.Mono;

namespace Storage
{
    /// <summary>
    /// Decorator class for different storage services
    /// </summary>
    public class StorageService : IDisposable
    {
        //TODO: key based subscription
        public event Action<string, object> OnChangeValue;
        
        private ISyncService StorageInstance;
        public IStorageApi Api;
        private bool IsDisposed;
        
        public StorageService(StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.PlayerPrefs:
                    StorageInstance = PlayerPrefsStorage.GetInstance();
                    Api = new PlayerPrefsApi();
                    break;
                case StorageType.FileStorage:
                    StorageInstance = FileStorageStorage.GetInstance();
                    Api = new FileStorageApi();
                    break;
                case StorageType.InMemory:
                    StorageInstance = InMemoryStorage.GetInstance();
                    Api = new InMemoryStorageApi();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(storageType), storageType, null);
            }

            OnChangeValue += StorageInstance.OnKeyValueUpdated;
        }
        
        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            IsDisposed = true;
            OnChangeValue -= StorageInstance.OnKeyValueUpdated;
        }

        public void Save()
        {
            Api.Commit();
        }

        public void DeleteAll()
        {
            Api.Clear();
            OnChangeValue?.Invoke("", null);
        }
        
        public void DeleteKey(string key)
        {
            Api.RemoveKey(key);
            OnChangeValue?.Invoke(key, null);
        }

        public bool HasKey(string key)
        {
            return Api.HasKey(key);
        }
        
        public bool GetBool(string key, bool defaultValue = false)
        {
            return Api.GetBool(key, defaultValue);
        }
        
        public int GetInt(string key, int defaultValue = 0)
        {
            return Api.GetInt(key, defaultValue);
        }
        
        public float GetFloat(string key, float defaultValue = 0f)
        {
            return Api.GetFloat(key, defaultValue);
        }

        public string GetString(string key, string defaultValue = "")
        {
            return Api.GetString(key, defaultValue);
        }
        
        public void SetBool(string key, bool value)
        {
            Api.SetBool(key, value);
            OnChangeValue?.Invoke(key, value);
        }
        
        public void SetInt(string key, int value)
        {
            Api.SetInt(key, value);
            OnChangeValue?.Invoke(key, value);
        }
        
        public void SetFloat(string key, float value)
        {
            Api.SetFloat(key, value);
            OnChangeValue?.Invoke(key, value);
        }

        public void SetString(string key, string value)
        {
            Api.SetString(key, value);
            OnChangeValue?.Invoke(key, value);
        }
    }
}