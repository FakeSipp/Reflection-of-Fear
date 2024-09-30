using UnityEngine;

public class SmallStrangeObject : MonoBehaviour
{
    public Animator eventObjects;
    [SerializeField] private RuntimeAnimatorController shakingAnim;

    private void Start()
    {
        SetAnimator();
    }

    public void Activate()
    {
        eventObjects.enabled = true;
    }
    public void Deactivate()
    {
        eventObjects.enabled = false;
        eventObjects.Rebind();
        eventObjects.Update(0);
    }

    private void SetAnimator()
    {
        eventObjects = gameObject.GetComponent<Animator>();

        if (!eventObjects)
        {
            eventObjects = gameObject.AddComponent<Animator>();
            eventObjects.enabled = false;
        }

        if (eventObjects.runtimeAnimatorController != shakingAnim)
        {
            eventObjects.runtimeAnimatorController = shakingAnim;
        }
    }
}
