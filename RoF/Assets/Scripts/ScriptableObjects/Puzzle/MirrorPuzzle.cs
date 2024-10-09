using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

[CreateAssetMenu(menuName = "Object/MirrorPuzzle")]
public class MirrorPuzzle : ObjectClass
{
    public string text1 = "too bright";
    public string text2 = "5197";
    public bool isClean = false;
    public float delayCd = 1f;

    override public void Interacted(Transform transform)
    {
        isClean = true;
        CoroutineManager.Instance.WaitForSecondsCoroutine(delayCd, ResetClean);
    }

    private void ResetClean()
    {
        isClean = false;
    }
}
