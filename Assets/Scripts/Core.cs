using Storage;

public static class Core
{
    public static StorageService Storage;

    static Core()
    {
#if UNITY_WEBGL
        Storage = new StorageService(StorageType.InMemory);
#else
        Storage = new StorageService(StorageType.PlayerPrefs);
//        Storage = new StorageService(StorageType.FileStorage);
//        Storage = new StorageService(StorageType.InMemory);
#endif
    }
}