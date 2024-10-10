using UnityEngine;

public class ButtonunActivator : MonoBehaviour
{
    private MouseManager mouse;

    // กำหนด GameObject ที่ต้องการเปิดใช้งานใน Unity Editor
    public GameObject objectTounActivate;

    // ฟังก์ชันนี้จะถูกเรียกเมื่อกดปุ่ม

    private void Awake()
    {
        mouse = FindAnyObjectByType<MouseManager>();
    }

    private void Update()
    {
        if(gameObject.activeSelf)
        {
            mouse.UnlockMouse();
        }
    }

    public void unActivateObject()
    {
        mouse.LockMouse();
        if (objectTounActivate != null)
        {
            objectTounActivate.SetActive(false);
        }
    }
}
