using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Object/ComputerPuzzle")]
public class ComputerPuzzle : ObjectClass
{
    public GameObject puzzleUI;
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