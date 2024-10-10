using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPuzzleHandle : MonoBehaviour
{
    public bool open = false;
    public Door door;

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            door.locked = false;
        }
    }
}
