using System;
using UnityEngine;

public class ObjectSetting : MonoBehaviour
{
    public ObjectClass obj;
    [HideInInspector] public LightSwitch lightSwitch;
    [HideInInspector] public DoorObject doorObject;
    [HideInInspector] public RealObject realObject;
    [HideInInspector] public MirrorPuzzle mirroPuzzleObject;
    [HideInInspector] public BoxPuzzle boxPuzzleObject;
    [HideInInspector] public ComputerPuzzle computerPuzzleObject;

    private void Awake()
    {
        if (obj == null) return;

        if (obj is LightSwitch)
        {
            Light();
        }
        else if (obj is DoorObject)
        {
            Door();
        }
        else if (obj is RealObject)
        {
            Object();
        }
        else if(obj is MirrorPuzzle) 
        {
            Mirror();
        }
        else if(obj is BoxPuzzle)
        {
            Box();
        }
        else if (obj is ComputerPuzzle)
        {
            Computer();
        }
    }

    private void Computer()
    {
        computerPuzzleObject = obj as ComputerPuzzle;
    }
    private void Box()
    {
        boxPuzzleObject = obj as BoxPuzzle;
    }

    private void Mirror()
    {
        mirroPuzzleObject = obj as MirrorPuzzle;
    }

    private void Object()
    {
        realObject = obj as RealObject;
    }

    private void Door()
    {
        doorObject = obj as DoorObject;
        Door thisDoor = GetComponent<Door>();
        if (thisDoor != null)
        {
            doorObject.door = thisDoor;
        }
        else
        {
            Debug.LogWarning("Door script not found in the scene");
        }
    }

    private void Light()
    {
       lightSwitch = obj as LightSwitch;
       PowerCut powerScript = FindAnyObjectByType<PowerCut>();
       if (powerScript != null)
       {
            lightSwitch.light = powerScript;
       }
       else
       {
            Debug.LogWarning("PowerCut script not found in the scene");
       }
    }
}
