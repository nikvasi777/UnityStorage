namespace Storage.Base
{
    public class FileStorageApi : InMemoryStorageApi
    {
        public const string StorageName = "UserSaves";
        
        
        public FileStorageApi()
        {
            Storage = PlayerFiles.ReadFromFile<StorageData>(StorageName);
            if (Storage == null)
            {
                Storage = new StorageData();
            }
        }

        public override void Commit()
        {
            PlayerFiles.SaveToFile(StorageName, Storage);
        }
    }
}