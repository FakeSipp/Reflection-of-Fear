<<<<<<< Updated upstream
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
=======
<<<<<<< HEAD
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
=======
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
>>>>>>> 5ba9edfe0343a919a16df21e03fa12da4750336b
>>>>>>> Stashed changes
