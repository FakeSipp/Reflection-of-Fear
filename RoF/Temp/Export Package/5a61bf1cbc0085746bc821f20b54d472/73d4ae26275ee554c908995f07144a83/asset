using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MouseLookAround : MonoBehaviour
{
    [Header("Mouse Sensitivity")]
    public float mouseSensitivity = 100f;
    private float sensitivity;

    [Header("Mouse Scroll Input")]
    float xRotation = 0;
    float yRotation = 0;
    float mouseX;
    float mouseY;

    [Header("Player")]
    public Transform player;

    [Header("Player' reflection")]
    public GameObject reflection;  
    
    void Start()
    {
        sensitivity = mouseSensitivity;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //GetMouseInput();
        LookAround();
    }

    private void LookAround()
    {
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        player.Rotate(Vector3.up * mouseX);

        if(reflection != null){
            reflection.transform.rotation = Quaternion.Euler(-xRotation, -yRotation, 0);
        }
    }

    //private void GetMouseInput()
    //{
    //    mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime;
    //    mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime;

    //    yRotation += mouseX;

    //    xRotation -= mouseY;
    //    xRotation = Mathf.Clamp(xRotation, -90, 90);
    //}

    public void StopLook(int n){
        if(n == 0){
            sensitivity = mouseSensitivity;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
        sensitivity = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
