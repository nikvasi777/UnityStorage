using System.Collections.Generic;

namespace Storage.Base
{
    public class InMemoryStorageApi : IStorageApi
    {
        public class StorageData
        {
            public Dictionary<string, bool> BoolStorage = new Dictionary<string, bool>();
            public Dictionary<string, int> IntStorage = new Dictionary<string, int>();
            public Dictionary<string, float> FloatStorage = new Dictionary<string, float>();
            public Dictionary<string, string> StringStorage = new Dictionary<string, string>();
        }

        public StorageData Storage = new StorageData();


        public virtual void Commit()
        {
        }

        public void Clear()
        {
            Storage.BoolStorage.Clear();
            Storage.IntStorage.Clear();
            Storage.FloatStorage.Clear();
            Storage.StringStorage.Clear();
        }

        public void RemoveKey(string key)
        {
            if (Storage.BoolStorage.ContainsKey(key))
            {
                Storage.BoolStorage.Remove(key);
            }
            else if (Storage.IntStorage.ContainsKey(key))
            {
                Storage.IntStorage.Remove(key);
            }
            else if (Storage.FloatStorage.ContainsKey(key))
            {
                Storage.FloatStorage.Remove(key);
            }
            else if (Storage.StringStorage.ContainsKey(key))
            {
                Storage.StringStorage.Remove(key);
            }
        }

        public bool HasKey(string key)
        {
            if (Storage.BoolStorage.ContainsKey(key))
            {
                return true;
            }
            else if (Storage.IntStorage.ContainsKey(key))
            {
                return true;
            }
            else if (Storage.FloatStorage.ContainsKey(key))
            {
                return true;
            }
            else if (Storage.StringStorage.ContainsKey(key))
            {
                return true;
            }

            return false;
        }

        public bool GetBool(string key, bool defaultValue = false)
        {
            if (Storage.BoolStorage.ContainsKey(key))
                return Storage.BoolStorage[key];

            return defaultValue;
        }

        public void SetBool(string key, bool value)
        {
            Storage.BoolStorage[key] = value;
        }

        public int GetInt(string key, int defaultValue = 0)
        {
            if (Storage.IntStorage.ContainsKey(key))
                return Storage.IntStorage[key];

            return defaultValue;
        }

        public void SetInt(string key, int value)
        {
            Storage.IntStorage[key] = value;
        }

        public float GetFloat(string key, float defaultValue = 0)
        {
            if (Storage.FloatStorage.ContainsKey(key))
                return Storage.FloatStorage[key];

            return defaultValue;
        }

        public void SetFloat(string key, float value)
        {
            Storage.FloatStorage[key] = value;
        }

        public string GetString(string key, string defaultValue = "")
        {
            if (Storage.StringStorage.ContainsKey(key))
                return Storage.StringStorage[key];

            return defaultValue;
        }

        public void SetString(string key, string value)
        {
            Storage.StringStorage[key] = value;
        }
    }
}