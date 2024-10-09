using UnityEngine;

public class BoxPuzzleHandle : MonoBehaviour
{
    public bool open = false;
    public GameObject pivot;

    private void OpenTheBox()
    {
        pivot.transform.localRotation = pivot.transform.localRotation = Quaternion.Euler(110, 0, 0);
    }
}
