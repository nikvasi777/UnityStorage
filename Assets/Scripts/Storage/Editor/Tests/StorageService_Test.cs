using Storage.Base;
using Storage.Utils;

using NUnit.Framework;
#if UNITY_2017_1_OR_NEWER
using UnityEngine.TestTools;
#endif

namespace Storage.Tests
{
    public class StorageService_Test
    {
        [Test]
        public void UnityObject_TestSimplePasses()
        {
            var storage = new StorageService(StorageType.PlayerPrefs);
            
            storage.SetBool("test_key_bool", true);
            Assert.That(storage.GetBool("test_key_bool"), Is.EqualTo(true));
            
            storage.SetInt("test_key_int", 11);
            Assert.That(storage.GetInt("test_key_int"), Is.EqualTo(11));
            
            storage.SetFloat("test_key_float", 13.37f);
            Assert.That(storage.GetFloat("test_key_float"), Is.EqualTo(13.37f));
            
            storage.SetString("test_key_str", "value");
            Assert.That(storage.GetString("test_key_str"), Is.EqualTo("value"));
            
            
            storage = new StorageService(StorageType.InMemory);
            
            storage.SetBool("test_key_bool", true);
            Assert.That(storage.GetBool("test_key_bool"), Is.EqualTo(true));
            
            storage.SetInt("test_key_int", 11);
            Assert.That(storage.GetInt("test_key_int"), Is.EqualTo(11));
            
            storage.SetFloat("test_key_float", 13.37f);
            Assert.That(storage.GetFloat("test_key_float"), Is.EqualTo(13.37f));
            
            storage.SetString("test_key_str", "value");
            Assert.That(storage.GetString("test_key_str"), Is.EqualTo("value"));
            
            
            storage = new StorageService(StorageType.FileStorage);
            
            storage.SetBool("test_key_bool", true);
            Assert.That(storage.GetBool("test_key_bool"), Is.EqualTo(true));
            
            storage.SetInt("test_key_int", 11);
            Assert.That(storage.GetInt("test_key_int"), Is.EqualTo(11));
            
            storage.SetFloat("test_key_float", 13.37f);
            Assert.That(storage.GetFloat("test_key_float"), Is.EqualTo(13.37f));
            
            storage.SetString("test_key_str", "value");
            Assert.That(storage.GetString("test_key_str"), Is.EqualTo("value"));
            

            storage.Save();

            string savedFile = PlayerFiles.UnitySavesPath + FileStorageApi.StorageName;
            string jsonData = Serializer.Serialize((storage.Api as FileStorageApi)?.Storage);
            
            Assert.That(PlayerFiles.FileExists(savedFile), Is.EqualTo(true));
            
            Assert.That(PlayerFiles.ReadAllText(savedFile) == jsonData, Is.EqualTo(true));
        }
    }
}
