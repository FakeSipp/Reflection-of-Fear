using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteReflection : MonoBehaviour
{
    public GameObject reflection;
    public GameObject ghost;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            reflection.SetActive(false);
            ghost.SetActive(true);
        }
    }
}
