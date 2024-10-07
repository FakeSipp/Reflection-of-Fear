using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveReflection : MonoBehaviour
{
    public GameObject reflection;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            reflection.gameObject.SetActive(true);
        }
    }
}
