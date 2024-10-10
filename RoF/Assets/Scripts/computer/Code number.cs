using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Codenumber : MonoBehaviour
{
    [SerializeField] private TMP_Text Ans;
    [SerializeField] private GameObject uiToHide; // GameObject ของ UI ที่จะซ่อน

    private MouseManager mouse;

    public Door door;

    private string Answer = "5197";
    private float resetDelay = 0.5f;

    private void Awake()
    {
        mouse = FindAnyObjectByType<MouseManager>();
    }

    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Execute()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "Correct";
            StartCoroutine(HideUIAfterDelay()); // เรียก Coroutine เพื่อปิด UI หลังจากแสดง "Correct"
        }
        else
        {
            Ans.text = "Invalid";
            StartCoroutine(ResetTextAfterDelay()); // ถ้าไม่ถูกต้อง รีเซ็ตข้อความกลับไปเป็นว่างเปล่า
        }
    }

    // Coroutine สำหรับซ่อน UI หลังจากแสดงข้อความ "Correct"
    private IEnumerator HideUIAfterDelay()
    {
        yield return new WaitForSeconds(resetDelay); // รอเวลาก่อนซ่อน UI
        mouse.LockMouse();
        if (door != null)
        {
            door.locked = false;
            PlayerWordsManager word = FindAnyObjectByType<PlayerWordsManager>();
            word.ExitDoorOpenText();
        }
        uiToHide.SetActive(false); // ปิด UI
    }

    // Coroutine สำหรับรีเซ็ตข้อความเมื่อกรอกข้อมูลผิด
    private IEnumerator ResetTextAfterDelay()
    {
        yield return new WaitForSeconds(resetDelay);
        Ans.text = "";
    }
}