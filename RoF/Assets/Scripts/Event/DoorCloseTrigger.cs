using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseTrigger : MonoBehaviour
{
    public List<Door> doors;
    public bool isTrigger = false;
    public bool wasPlaySound = false;

    private void Update()
    {
        if (!isTrigger) return;
        foreach (Door door in doors)
        {
            door.Close();
            door.open = false;
            door.locked = true;
            if(!wasPlaySound)
            {
                door.OpenDoorSound();
                wasPlaySound = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Door door in doors)
            {
                isTrigger = true;
            }
        }
    }
}
