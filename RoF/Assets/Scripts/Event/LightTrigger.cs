using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public PowerCut lightCutScript;

    private void Awake()
    {
        lightCutScript = FindAnyObjectByType<PowerCut>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lightCutScript.PowerOff();
        }
    }
}
