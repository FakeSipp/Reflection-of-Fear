using UnityEngine;

public class HauntedObject : MonoBehaviour
{
    public Animator hauntedObject;
    public bool canTriggerManyTime = true;
    public bool wasTriggered;
    [SerializeField] private RuntimeAnimatorController shakingAnim;

    private void Start()
    {
        SetAnimator();
    }

    public void Activate()
    {
        if (!canTriggerManyTime && wasTriggered)
            return;
        hauntedObject.enabled = true;
        wasTriggered = true;
    }
    public void Deactivate()
    {
        hauntedObject.enabled = false;
        hauntedObject.Rebind();
        hauntedObject.Update(0);
    }

    private void SetAnimator()
    {
        hauntedObject = gameObject.GetComponent<Animator>();

        if (!hauntedObject)
        {
            hauntedObject = gameObject.AddComponent<Animator>();
            hauntedObject.enabled = false;
        }

        if (hauntedObject.runtimeAnimatorController != shakingAnim)
        {
            hauntedObject.runtimeAnimatorController = shakingAnim;
        }
    }
}
