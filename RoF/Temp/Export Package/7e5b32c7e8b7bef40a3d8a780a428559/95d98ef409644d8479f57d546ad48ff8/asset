using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public Canvas ui;
    private bool isOpen = false;

    private PlayerController player;
    private MouseLookAround mouse;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        mouse = GameObject.FindObjectOfType<MouseLookAround>();
    }
    private void OpenUi()
    {
        if (isOpen)
        {
            player.StopMove();
            mouse.StopLook(1);
            ui.gameObject.SetActive(true);
        }
    }

    public void ToggleUi()
    {
        isOpen = !isOpen;
        OpenUi();
    }
}
