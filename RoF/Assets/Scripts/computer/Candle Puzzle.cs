using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button submitButton; // ปุ่มสำหรับกด "ตกลง"
    public GameObject[] objectsToHide; // ตัวแปรที่เก็บ GameObject ที่ต้องการปิด
    public Button resetButton; // ปุ่มรีเซ็ต

    private bool[] buttonPressed = new bool[3]; // ตัวแปรบอกว่าปุ่มแต่ละปุ่มถูกกดหรือยัง
    private int[] correctButtons = { 1, 3 }; // ปุ่มที่ต้องกดถูก (เช่น ปุ่ม 1 และ 3)
    private int correctCount = 0;
    private bool puzzleSolved = false;
    private bool incorrectButtonPressed = false; // ตรวจสอบว่ากดปุ่มผิดหรือไม่

    void Start()
    {
        // เพิ่ม listener ให้กับปุ่มแต่ละปุ่ม (กดได้ครั้งเดียว)
        button1.onClick.AddListener(() => PressButton(1));
        button2.onClick.AddListener(() => PressButton(2));
        button3.onClick.AddListener(() => PressButton(3));

        // เพิ่ม listener สำหรับปุ่ม "ตกลง"
        submitButton.onClick.AddListener(CheckSolution);

        // เพิ่ม listener สำหรับปุ่มรีเซ็ต
        resetButton.onClick.AddListener(ResetPuzzle);
    }

    // ฟังก์ชันที่ทำงานเมื่อกดปุ่มต่างๆ
    void PressButton(int buttonID)
    {
        if (!buttonPressed[buttonID - 1]) // ตรวจสอบว่าปุ่มถูกกดหรือยัง
        {
            buttonPressed[buttonID - 1] = true;
            Debug.Log("Button " + buttonID + " pressed");

            // ตรวจสอบว่าปุ่มที่กดเป็นปุ่มผิดหรือไม่
            if (buttonID != 1 && buttonID != 3)
            {
                incorrectButtonPressed = true;
                Debug.Log("Incorrect Button Pressed! Resetting...");
            }
        }
    }

    // ฟังก์ชันที่ทำงานเมื่อกดปุ่ม "ตกลง"
    void CheckSolution()
    {
        if (puzzleSolved) return; // ถ้า Puzzle ถูกแก้แล้วไม่ทำอะไรอีก

        if (incorrectButtonPressed) // ถ้ากดปุ่มผิด ระบบจะรีเซ็ตใหม่ทันที
        {
            Debug.Log("Wrong combination! Resetting...");
            ResetPuzzle();
            return;
        }

        correctCount = 0;

        // ตรวจสอบว่าปุ่มที่กดถูกต้องหรือไม่ (ต้องเป็นปุ่ม 1 และ 3 เท่านั้น)
        for (int i = 0; i < correctButtons.Length; i++)
        {
            if (buttonPressed[correctButtons[i] - 1])
            {
                correctCount++;
            }
        }

        if (correctCount == correctButtons.Length)
        {
            // ถ้ากดถูกทุกปุ่ม ให้ปิด GameObject ที่เลือก
            Debug.Log("Puzzle Solved!");
            puzzleSolved = true;
            HideObjects();
        }
        else
        {
            // ถ้ากดผิด ให้รีเซ็ตการกดปุ่ม
            Debug.Log("Wrong combination! Resetting...");
            ResetPuzzle();
        }
    }

    void HideObjects()
    {
        // ปิด GameObject ทุกอันใน array objectsToHide
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }
    }

    // ฟังก์ชันรีเซ็ต Puzzle
    public void ResetPuzzle()
    {
        correctCount = 0;
        puzzleSolved = false;
        incorrectButtonPressed = false; // รีเซ็ตสถานะของการกดปุ่มผิด

        // รีเซ็ตสถานะปุ่มที่ถูกกด
        for (int i = 0; i < buttonPressed.Length; i++)
        {
            buttonPressed[i] = false;
        }

        // แสดง GameObject ที่ถูกปิดไว้ใหม่
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(true);
        }

        Debug.Log("Puzzle Reset!");
    }
}
