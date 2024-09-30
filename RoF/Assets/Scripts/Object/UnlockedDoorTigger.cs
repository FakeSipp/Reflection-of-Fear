using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class UnlockedDoorTigger : MonoBehaviour
{
    public GameObject door;
    private Door doorScript;
    public RealObject obj;

    private void Start()
    {
        doorScript = door.transform.GetComponentInChildren<Door>();
        obj = GetComponent<ObjectSetting>().realObject;
    }

    private void Update()
    {
        if (doorScript.locked)
        {
            if (obj.isTouch)
            {
                doorScript.locked = false;
            }
        }
    }
}
