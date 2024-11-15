using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    // กำหนด GameObject ที่ต้องการเปิดใช้งานใน Unity Editor
    public GameObject objectToActivate;

    // ฟังก์ชันนี้จะถูกเรียกเมื่อกดปุ่ม
    public void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
