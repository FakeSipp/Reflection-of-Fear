using UnityEngine;

public class ErrorHandling : MonoBehaviour
{
    void Start()
    {
        MouseBugFix();
    }

    private void MouseBugFix()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
