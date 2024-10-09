using UnityEngine;
using System.Collections;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager instance;

    public static CoroutineManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("CoroutineManager");
                instance = obj.AddComponent<CoroutineManager>();
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }

    public void WaitForSecondsCoroutine(float seconds, System.Action callback)
    {
        StartCoroutine(WaitCoroutine(seconds, callback));
    }

    private IEnumerator WaitCoroutine(float seconds, System.Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback?.Invoke();
    }
}
