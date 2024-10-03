using System.Collections.Generic;
using UnityEngine;

public class PowerCut : MonoBehaviour
{
    public List<Light> lightBulbs;
    public bool isPowerOn = true;
    public AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PowerOff()
    {
        audio.Play();
        foreach (Light light in lightBulbs)
        {
            light.enabled = false;
        }
        isPowerOn = false;
    }
    public void PowerOn()
    {
        audio.Play();
        foreach (Light light in lightBulbs)
        {
            light.enabled = true;
        }
        isPowerOn = true;
    }
}
