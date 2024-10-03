using System.Collections.Generic;
using UnityEngine;

public class PowerCut : MonoBehaviour
{
    public List<Light> lightBulbs;
    public bool isPowerOn = true;

    //private void Start()
    //{
    //    lightBulbs = new List<Light>();

    //    foreach (Transform child in transform)
    //    {
    //        if (!child.GetComponent<Light>()) continue;
    //        lightBulbs.Add(child.GetComponent<Light>());
    //    }
    //}

    public void PowerOff()
    {
        foreach (Light light in lightBulbs)
        {
            light.enabled = false;
        }
        isPowerOn = false;
    }
    public void PowerOn()
    {
        foreach (Light light in lightBulbs)
        {
            light.enabled = true;
        }
        isPowerOn = true;
    }
}
