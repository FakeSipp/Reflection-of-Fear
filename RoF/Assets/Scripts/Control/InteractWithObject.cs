using UnityEngine;
using UnityEngine.InputSystem.HID;

public class InteractWithObject : MonoBehaviour
{
    [Header("Manager")]
    private InputManager input;

    [Header("Camera")]
    private Camera cam;

    [Header("Interaction Settings")]
    public float interactionDistance = 3f;
    public float interactionRadius = 3f;

    [Header("Interaction Cooldown")]
    public float cooldownTime = 1.0f;
    private float nextInteractionTime = 0f;

    void Awake()
    {
        cam = Camera.main;
        input = FindAnyObjectByType<InputManager>();
    }

    void Update()
    {
        HandleInteraction();
        Debug.DrawRay(transform.position, transform.forward * interactionDistance, Color.green);
    }

    private void HandleInteraction()
    {
        if (Time.time < nextInteractionTime) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // CHECK IF THE OBJECT IS WITHIN THE INTERACTION RADIUS AND IS INTERACTABLE
            float distanceToObject = Vector3.Distance(hit.point, transform.position);

            if (distanceToObject <= interactionRadius)
            {
                ObjectSetting objectSetting = hit.collider.GetComponent<ObjectSetting>();

                if (objectSetting != null)
                {
                    ObjectClass obj = objectSetting.obj;

                    if (obj != null)
                    {
                        if (input.InteractInput)
                        {
                            input.InteractInput = false;
                            print("Interacted");
                            obj.Interacted(transform);

                            nextInteractionTime = Time.time + cooldownTime;
                        }
                    }
                }
            }
        }
    }
}
