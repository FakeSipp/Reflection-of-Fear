using UnityEngine;

[CreateAssetMenu(menuName = "Object/MirrorPuzzle")]
public class MirrorPuzzle : ObjectClass
{
    public string text1 = "too bright";
    public string text2 = "5197";
    public bool isClean = false;

    override public void Interacted(Transform transform)
    {
        isClean = true;
    }
}
