using System.Collections.Generic;
using UnityEngine;

public class EventObjectManager : MonoBehaviour
{
    [System.Serializable]
    public class EventObject
    {
        [Header("Haunted Object")]
        public HauntedObject hauntedObj;

        [Header("Real Object")]
        public ObjectSetting realObj;
    }

    [Header("Event Objects")]
    public List<EventObject> eventObjects = new List<EventObject>();

    [Header("Audio")]
    public AudioClip shakingSound;

    [Header("Index & Count")]
    public int index;
    public int count;

    private void Start()
    {
        count = eventObjects.Count;

        foreach(EventObject eventObj in eventObjects){
            print("DO");
            HauntedObject hauntedObj = eventObj.hauntedObj;
            AudioSource audio = hauntedObj.GetComponent<AudioSource>();
            if (!audio)
                audio = hauntedObj.gameObject.AddComponent<AudioSource>();

            audio.clip = shakingSound;
            audio.loop = true;
            audio.spatialBlend = 1;
        }
    }

    public void Activate(int i)
    {
        if (i >= 0 && i < eventObjects.Count)
        {
            eventObjects[i].hauntedObj.Activate();
            index = i;

            PlaySound(eventObjects[i].hauntedObj.GetComponent<AudioSource>());
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
            StopSound(eventObjects[i].hauntedObj.GetComponent<AudioSource>());
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

        StopSound(eventObjects[index].hauntedObj.GetComponent<AudioSource>());
    }
    public bool IsBanish(int i)
    {
        return eventObjects[i].realObj.realObject.isTouch;
    }
    public bool IsBanish()
    {
        return eventObjects[index].realObj.realObject.isTouch;
    }

    public void PlaySound(AudioSource audio)
    {
        audio.Play();
    }
    public void StopSound(AudioSource audio)
    {
        audio.Stop();
    }
}
