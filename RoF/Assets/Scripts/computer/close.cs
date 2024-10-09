using UnityEngine;

public class ButtonunActivator : MonoBehaviour
{
    // กำหนด GameObject ที่ต้องการเปิดใช้งานใน Unity Editor
    public GameObject objectTounActivate;

    // ฟังก์ชันนี้จะถูกเรียกเมื่อกดปุ่ม
    public void unActivateObject()
    {
        if (objectTounActivate != null)
        {
            objectTounActivate.SetActive(false);
        }
    }
}
