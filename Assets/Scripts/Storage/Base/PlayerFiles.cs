using System.IO;
using System.Text;
using Storage.Utils;
using UnityEngine;

namespace Storage.Base
{
    public static class PlayerFiles
    {
        public static string ApplicationIdentifier { get; set; }

        public static string UnitySavesPath
        {
            get
            {
                if (_unityPath != null)
                    return _unityPath;

                _unityPath = GetMainPath();
                return _unityPath;
            }
        }

        private static string _unityPath;
        private const string BackupExt = ".bak";


        public static bool HasFile(string key)
        {
            string fileName = UnitySavesPath + key;
            return FileExists(fileName);
        }

        public static void SaveToFile<T>(string key, T obj)
        {
            WriteAllText(UnitySavesPath + key, Serializer.Serialize(obj));
        }

        public static T ReadFromFile<T>(string key)
        {
            string fileName = UnitySavesPath + key;

            if (!FileExists(fileName))
                return default;

            return Serializer.Deserialize<T>(ReadAllText(fileName));
        }

        public static void SaveToFileBackup<T>(string key, T obj)
        {
            string fileName = UnitySavesPath + key;

            if (FileExists(fileName))
            {
                string backup = fileName + BackupExt;

                if (FileExists(backup))
                {
                    FileDelete(backup);
                }

                FileMove(fileName, backup);
            }

            WriteAllText(fileName, Serializer.Serialize(obj));
        }

        public static T ReadFromFileBackup<T>(string key)
        {
            string fileName = UnitySavesPath + key;
            string backup = fileName + BackupExt;

            if (FileExists(fileName))
            {
                T result = Serializer.Deserialize<T>(ReadAllText(fileName));
                if (result != null)
                    return result;
            }

            if (FileExists(backup))
            {
                T result = Serializer.Deserialize<T>(ReadAllText(backup));
                if (result != null)
                    return result;
            }

            return default;
        }

        public static void RemoveFiles(string key)
        {
            string fileName = UnitySavesPath + key;
            string backup = fileName + BackupExt;

            FileDelete(fileName);
            FileDelete(backup);
        }

        public static bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        private static void FileDelete(string path)
        {
            File.Delete(path);
        }

        private static void FileMove(string sourceFileName, string destFileName)
        {
            File.Move(sourceFileName, destFileName);
        }

        private static void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents, Encoding.UTF8);
        }

        private static void AppendAllText(string path, string contents)
        {
            File.AppendAllText(path, contents);
        }

        public static string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        private static string GetMainPath()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			string path;
			try 
			{
				using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) 
				{
					using (AndroidJavaObject obj_Activity =
 cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) 
					{
						path = obj_Activity.Call<AndroidJavaObject>("getFilesDir").Call<string>("getAbsolutePath"); 
						if (path != null)
						{
							return path + "/";
						}
						
						Debug.LogWarning("Do fallback");
						try 
						{
							path = "/data/data/" + ApplicationIdentifier + "/files/";
							if (DirectoryExists(path))
								return path;
							
							Debug.LogError("fallback path not found: " + path);
						}
						catch (Exception e)
						{
							Debug.LogError("fallback path not found and error: " + e.Message);
						}
					}
				}
			}
			catch(Exception e) 
			{
				Debug.Log("Error when getting path" + e.ToString());
			}
#endif

            return Application.persistentDataPath + "/";
        }
    }
}