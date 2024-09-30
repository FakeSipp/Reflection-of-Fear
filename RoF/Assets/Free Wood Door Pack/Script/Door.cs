using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour {
	public Door reflect;
	public bool open;
	public bool locked;
	public float smooth = 1.0f;
	public float DoorOpenAngle = -90.0f;
    public float DoorCloseAngle = 0.0f;
	public AudioSource asource;
	public AudioClip openDoor,closeDoor;
	void Start () {
		asource = GetComponent<AudioSource> ();
		open = false;
	}
	
	void Update ()
    {
        HandleDoor();
    }

    private void HandleDoor()
    {
        if (locked) return;
        if (open)
        {
            var target = Quaternion.Euler(0, DoorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);
        }
        else
        {
            var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * 5 * smooth);
        }

        if (reflect == null) return;
        reflect.open = open;
    }

    public void OpenDoorSound(){
		asource.clip = open?openDoor:closeDoor;
		asource.Play ();
	}
}