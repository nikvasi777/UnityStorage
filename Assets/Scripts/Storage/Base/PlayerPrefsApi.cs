using UnityEngine;

namespace Storage.Base
{
    public class PlayerPrefsApi : IStorageApi
    {
        public void Commit()
        {
            PlayerPrefs.Save();
        }

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }
        
        public void RemoveKey(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }
        
        public bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }
        
        public bool GetBool(string key, bool defaultValue = false)
        {
            return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
        }
        
        public void SetBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }
        
        public int GetInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }
        
        public void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }
        
        public float GetFloat(string key, float defaultValue = 0f)
        {
            return PlayerPrefs.GetFloat(key, defaultValue);
        }
        
        public void SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }
        
        public string GetString(string key, string defaultValue = "")
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }
        
        public void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }
    }
}