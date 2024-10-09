using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Object/Rags")]
public class RagsObject : ObjectClass
{
    public bool isTouch;
    public float waitTime = 2f;

    override public void Interacted(Transform transform)
    {
        isTouch = true;
        CoroutineManager.Instance.WaitForSecondsCoroutine(waitTime, ResetTouch);
    }

    private void ResetTouch()
    {
        isTouch = false;
    }
}
