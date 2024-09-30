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
        CoroutineRunner.Instance.StartCoroutine(ResetTouch());
    }

    private IEnumerator ResetTouch()
    {
        yield return new WaitForSeconds(waitTime);
        isTouch = false;
    }
}
