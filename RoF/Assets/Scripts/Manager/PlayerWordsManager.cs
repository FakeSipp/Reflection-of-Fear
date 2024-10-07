using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerWordsManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text textUI;

    [Header("Texts")]
    public string startGameText = "Where am I?";
    public string hauntText = "I see something moving in the mirror. I'm feeling bad.";
    public string openLightText = "It's too dark. I see the switch next to the door.";
    public string mirrorPuzzleText = "I got some rag. I think I can use it to clean something.";
    public string exitDoorOpenText = "I am hearing something at that black door.";

    [Header("Settings")]
    public float delayBeforeClear = 10.0f;  

    public void StartGameText()
    {
        textUI.text = startGameText;
        StartCoroutine(ClearTextByDelay());  
    }
    public void HauntText()
    {
        textUI.text = hauntText;
        StartCoroutine(ClearTextByDelay());  
    }
    public void OpenLightText()
    {
        textUI.text = openLightText;
        StartCoroutine(ClearTextByDelay());  
    }
    public void MirrorPuzzleText()
    {
        textUI.text = mirrorPuzzleText;
        StartCoroutine(ClearTextByDelay());  
    }
    public void ExitDoorOpenText()
    {
        textUI.text = exitDoorOpenText;
        StartCoroutine(ClearTextByDelay());  
    }

    private IEnumerator ClearTextByDelay()
    {
        yield return new WaitForSeconds(delayBeforeClear);
        ClearText();
    }

    public void ClearText()
    {
        textUI.text = "";
    }
}
