using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private EventManager eventManager;
    [SerializeField] private int eventIndex;

    private void Start()
    {
        if (eventManager == null)
        {
            eventManager = FindObjectOfType<EventManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger");
        if (other.CompareTag("Player"))
        {
            eventManager.TriggerOneEvent(eventIndex);
        }
    }
}
