using UnityEngine;

[CreateAssetMenu(menuName = "Object/Door")]
public class DoorObject : ObjectClass
{
    [Header("Door Parameters")]
    public Door door;
    public bool open;

    override public void Interacted(Transform transform)
    {
        if (door != null)
        {
            if (!door.locked)
            {
                open = !open;
                door.open = open;
                door.OpenDoorSound();
            }
        }
    }
}
