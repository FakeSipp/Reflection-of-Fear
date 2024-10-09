using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Codenumber : MonoBehaviour
{
    [SerializeField] private TMP_Text Ans;
    [SerializeField] private GameObject uiToHide; // GameObject ของ UI ที่จะซ่อน

    private string Answer = "123456";
    private float resetDelay = 0.5f;

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
        uiToHide.SetActive(false); // ปิด UI
    }

    // Coroutine สำหรับรีเซ็ตข้อความเมื่อกรอกข้อมูลผิด
    private IEnumerator ResetTextAfterDelay()
    {
        yield return new WaitForSeconds(resetDelay);
        Ans.text = "";
    }
}