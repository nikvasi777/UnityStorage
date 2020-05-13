namespace Storage.Mono
{
    public interface ISyncService
    {
        void OnKeyValueUpdated(string key, object value);
    }
}