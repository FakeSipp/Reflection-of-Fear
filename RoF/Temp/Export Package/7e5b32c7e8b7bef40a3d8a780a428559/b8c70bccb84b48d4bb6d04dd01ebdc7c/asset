using UnityEngine;

public class CenterPoint : MonoBehaviour
{
    public enum LockAxis { X, Z }

    [Header("Objects To Center")]
    [SerializeField] private Transform originObj;  // THE PLAYER OR MAIN OBJECT
    [SerializeField] private Transform childObj;   // THE SHADOW OR REFLECTED OBJECT 

    [Header("Center Parameters")]
    [SerializeField] private Vector3 centerPoint;  // THE MIRROR POINT
    [SerializeField] private LockAxis lockAxis = LockAxis.X;  // AXIS TO LOCK

    private void Awake()
    {
        // SET CENTER POINT TO THIS OBJECT'S POSITION
        centerPoint = transform.position;
    }

    private void Update()
    {
        // ENSURE BOTH OBJECTS ARE ASSIGNED
        if (originObj == null || childObj == null) return;

        // REFLECT THE CHILD OBJECT'S POSITION TO MIRROR THE ORIGIN OBJECT'S POSITION
        childObj.position = ReflectPosition(originObj.position, centerPoint);
    }

    // FUNCTION TO CALCULATE THE REFLECTED POSITION OF AN OBJECT WITH THE LOCKED AXIS
    private Vector3 ReflectPosition(Vector3 objPosition, Vector3 mirrorPoint)
    {
        // GET THE DIRECTION FROM THE MIRROR POINT TO THE OBJECT
        Vector3 directionToObj = objPosition - mirrorPoint;

        // REFLECT THE POSITION WHILE LOCKING THE SELECTED AXIS
        Vector3 reflectedPosition = mirrorPoint - directionToObj;

        switch (lockAxis)
        {
            case LockAxis.X:
                // LOCK X AXIS
                reflectedPosition.x = objPosition.x;
                break;
            case LockAxis.Z:
                // LOCK Z AXIS
                reflectedPosition.z = objPosition.z;
                break;
        }
        reflectedPosition.y = objPosition.y;
        return reflectedPosition;
    }
}
