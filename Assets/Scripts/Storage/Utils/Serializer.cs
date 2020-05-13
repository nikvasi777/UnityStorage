using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Storage.Utils
{
    public class Serializer
    {
        public static string Serialize<T>(T data)
        {
            try
            {
                return JsonConvert.SerializeObject(data, new JsonSerializerSettings { 
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            catch (Exception e)
            {
                Debug.LogError("Serialize type " + typeof(T) + " : " + e);
            }
            return "";
        }
    
        public static T Deserialize<T>(string data)
        {
            if (data == null)
                data = "";
                        
            try
            {
                return JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception e)
            {
                string debugJsonPart = data.Substring(0, data.Length < 200 ? data.Length : 200)
                    .Replace("\n", " ");
                Debug.LogError("Deserialize type " + typeof(T) + " : '" + debugJsonPart + "' : " + e);
            }
            return default(T);
        }
    }
}