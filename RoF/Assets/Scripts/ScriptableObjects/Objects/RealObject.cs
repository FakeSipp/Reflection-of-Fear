using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Object/Object")]
public class RealObject : ObjectClass
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
