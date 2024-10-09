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
    [HideInInspector] public RawImage videoPlayer;

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
        videoPlayer = playerUI.transform.Find("VideoPlayer").GetComponent<RawImage>();
    }

    public void SetActivePlayerUI(bool status)
    {
        if (!playerUI) return;
        playerUI.enabled = status;
    }
}
