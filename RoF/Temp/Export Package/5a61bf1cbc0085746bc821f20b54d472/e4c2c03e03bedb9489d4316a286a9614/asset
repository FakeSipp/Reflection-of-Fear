using System.Collections.Generic;
using UnityEngine;

public class EventObjectManager : MonoBehaviour
{
    [System.Serializable] 
    public class EventObject
    {
        public HauntedObject hauntedObj; 
        public ObjectSetting realObj;       
    }

    public List<EventObject> eventObjects = new List<EventObject>();
    public int index;
    public int count;

    private void Start()
    {
        count = eventObjects.Count;
    }

    public void Activate(int i)
    {
        if (i >= 0 && i < eventObjects.Count)
        {
            eventObjects[i].hauntedObj.Activate();
            index = i;
        }
        else
        {
            print("Index out of range (Activate)");
        }
    }
    public void Deactivate(int i)
    {
        if (i >= 0 && i < eventObjects.Count)
        {
            eventObjects[i].hauntedObj.Deactivate();
        }
        else
        {
            print("Index out of range (Deactivate)");
        }
    }
    public void Deactivate()
    {
        eventObjects[index].hauntedObj.Deactivate();
        index = -1;
    }
    public bool IsBanish(int i)
    {
        print(eventObjects[i].realObj.realObject.isTouch);
        return eventObjects[i].realObj.realObject.isTouch;
    }
    public bool IsBanish()
    {
        return eventObjects[index].realObj.realObject.isTouch;
    }
}
