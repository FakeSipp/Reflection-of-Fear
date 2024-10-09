using UnityEngine;
using UnityEngine.UI;

public class ButtonImageSwitcher : MonoBehaviour
{
    public Button targetButton;  // ปุ่มที่ต้องการเปลี่ยนรูป
    public Sprite defaultSprite; // รูปภาพเริ่มต้นของปุ่ม
    public Sprite pressedSprite; // รูปภาพที่จะเปลี่ยนเมื่อกดปุ่ม
    public Button resetButton;   // ปุ่มรีเซ็ต

    private bool isPressed = false; // ตัวแปรบอกสถานะของปุ่ม

    void Start()
    {
        // ตรวจสอบว่า targetButton มีการเชื่อมโยงหรือไม่
        if (targetButton != null)
        {
            // เพิ่ม Listener สำหรับการกดปุ่ม
            targetButton.onClick.AddListener(SwitchImage);
        }

        // เพิ่ม Listener สำหรับการรีเซ็ตปุ่ม
        resetButton.onClick.AddListener(ResetButtonImage);
    }

    void SwitchImage()
    {
        // ถ้ายังไม่เคยถูกกด ให้เปลี่ยนรูปเป็น pressedSprite
        if (!isPressed)
        {
            targetButton.image.sprite = pressedSprite;
            isPressed = true; // เปลี่ยนสถานะให้เป็นกดแล้ว
            Debug.Log("Button pressed, image switched.");
        }
    }

    // ฟังก์ชันรีเซ็ตรูปปุ่ม
    public void ResetButtonImage()
    {
        // รีเซ็ตกลับไปที่รูปภาพเริ่มต้น
        targetButton.image.sprite = defaultSprite;
        isPressed = false; // รีเซ็ตสถานะให้ปุ่มกดได้อีกครั้ง
        Debug.Log("Button Reset!");
    }
}
