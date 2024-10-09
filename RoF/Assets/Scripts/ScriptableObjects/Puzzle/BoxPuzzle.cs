using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Object/BoxPuzzle")]
public class BoxPuzzle : ObjectClass
{
    public GameObject puzzleUI;
    public bool isOpen = false;
    public bool isTouch = false;
    public float deladyCd = 1f;

    override public void Interacted(Transform transform)
    {
        if (!isTouch)
        {
            isTouch = true;
            CoroutineManager.Instance.WaitForSecondsCoroutine(deladyCd, ResetTouch);
        }
    }

    private void ResetTouch()
    {
        isTouch = false;
    }
}
