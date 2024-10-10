using UnityEngine;

public class BoxPuzzleHandle : MonoBehaviour
{
    public bool open = false;
    public GameObject pivot;
    public GameObject pivotReflect;

    private void Update()
    {
        if(open)
            OpenTheBox();
    }

    private void OpenTheBox()
    {
        pivot.transform.localRotation = pivot.transform.localRotation = Quaternion.Euler(-110, 0, 0);
        pivotReflect.transform.localRotation = pivot.transform.localRotation = Quaternion.Euler(-110, 0, 0);
    }
}
