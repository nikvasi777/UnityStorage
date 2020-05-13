using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        Core.Storage.SetInt("test_key", 11);
        int t1 = Core.Storage.GetInt("test_key");
        Debug.Assert(t1 == 11);
    }
}