using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Player UI")]
    public Canvas playerUI;
    [HideInInspector] public Slider sanityBar;
    [HideInInspector] public Slider flashlightBar;
    [HideInInspector] public Image computerUI;
    [HideInInspector] public Image keypadUI;
    [HideInInspector] public TextMeshPro eventWarning;
    [HideInInspector] public RawImage videoPlayer;

    [Header("Player Texts")]
    public List<TextData> playerTextData; 

    private Dictionary<string, string> playerText = new Dictionary<string, string>(); 

    private static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (var data in playerTextData)
        {
            if (!playerText.ContainsKey(data.key))
            {
                playerText.Add(data.key, data.value);
            }
        }

        SettingUI();
    }

    private void SettingUI()
    {
        if (!playerUI)
        {
            Debug.LogWarning("NO PLAYER UI ASSIGN!!");
            return;
        }
        sanityBar = playerUI.transform.Find("HPBar").GetComponent<Slider>();
        flashlightBar = playerUI.transform.Find("FlashlightBar").GetComponent<Slider>();
        computerUI = playerUI.transform.Find("ComputerUI").GetComponent<Image>();
        keypadUI = playerUI.transform.Find("KeypadUI").GetComponent<Image>();
        eventWarning = playerUI.transform.Find("EventWarning").GetComponent<TextMeshPro>();
        videoPlayer = playerUI.transform.Find("VideoPlayer").GetComponent<RawImage>();
    }

    public void SetActivePlayerUI(bool status)
    {
        if (!playerUI) return;
        playerUI.enabled = status;
    }

    public void ShowText(string textName)
    {
        if (playerText.TryGetValue(textName, out string value))
        {
            eventWarning.text = value;
        }
        else
        {
            Debug.LogWarning($"Text {textName} not found in playerText dictionary.");
        }
    }
}

[System.Serializable]
public class TextData
{
    public string key;
    public string value;
}