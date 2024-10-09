using UnityEngine;
using TMPro;

public class MirrorPuzzleTextHandle : MonoBehaviour
{
    private ObjectSetting objectSetting;
    public TMP_Text textMeshPro;

    void Start()
    {
        objectSetting = GetComponent<ObjectSetting>();
    }

    void Update()
    {
        if (objectSetting == null || textMeshPro == null) return;
        MirrorPuzzle mirrorPuzzle = objectSetting.mirroPuzzleObject;
        LightSwitch light = GameObject.Find("Switch").GetComponent<ObjectSetting>().lightSwitch;

        if (mirrorPuzzle.isClean)
        {
            textMeshPro.enabled = true;
        }

        if (light.light.isPowerOn)
        {
            textMeshPro.text = mirrorPuzzle.text1;
        }
        else
        {
            textMeshPro.text = mirrorPuzzle.text2;
        }
    }
}
