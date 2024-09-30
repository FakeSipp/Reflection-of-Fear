using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Object/LightSwitch")]
public class LightSwitch : ObjectClass
{
    [Header("Light Parameters")]
    [SerializeField] public PowerCut light;

    override public void Interacted(Transform transform)
    {
        light.isPowerOn = !light.isPowerOn;
        if (light.isPowerOn)
        {
            ActivateLight();
        }
        else
        {
            DeactivateLight();
        }
    }

    private void ActivateLight()
    {
        light.PowerOn();
    }

    private void DeactivateLight()
    {
        light.PowerOff();
    }
}
