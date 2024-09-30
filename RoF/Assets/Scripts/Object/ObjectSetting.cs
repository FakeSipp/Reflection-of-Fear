using UnityEngine;

public class ObjectSetting : MonoBehaviour
{
    [HideInInspector] public ObjectClass obj;
    [HideInInspector] public LightSwitch lightSwitch;
    [HideInInspector] public DoorObject door;
    public RealObject realObject;

    private void Start()
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
    }

    private void Object()
    {
        realObject = obj as RealObject;
    }

    private void Door()
    {
        door = obj as DoorObject;
        Door doorControl = transform.GetComponent<Door>();
        if (doorControl != null)
        {
            door.door = doorControl;
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
