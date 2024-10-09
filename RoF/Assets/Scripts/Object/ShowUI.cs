using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    [Header("Box Puzzle")]
    public GameObject candleUI;
    public BoxPuzzle box;

    void Update()
    {
        if (box != null)
        {
            if(box.isTouch) 
            {
                candleUI.SetActive(true);
            }
        }
    }
}
