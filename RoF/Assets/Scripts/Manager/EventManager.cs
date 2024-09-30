using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private EventObjectManager eventObjectManager;
    [SerializeField] private PowerCut light;

    [Header("Event Parameters")]
    [SerializeField] private bool start;
    [SerializeField] private int randomIndex;
    [SerializeField] private int oneEventIndex;
    [SerializeField] private float damage;
    [SerializeField] private float cdTime;
    [SerializeField] private bool onCooldown;
    [SerializeField] private bool isHappening;

    [Header("Power Cut Parameters")]
    [SerializeField] private float powerCutCheckInterval = 5f;
    [SerializeField, Range(0f, 1f)] private float powerCutChance = 0.005f; 

    [Header("Player Parameters")]
    private Sanity sanity;

    public InputManager input;
    private float powerCutCooldown;

    private void Awake()
    {
        input = FindAnyObjectByType<InputManager>();
        eventObjectManager = FindAnyObjectByType<EventObjectManager>();
        light = FindAnyObjectByType<PowerCut>();
        sanity = FindAnyObjectByType<Sanity>();

        cdTime = Random.Range(15, 30);
        powerCutCooldown = powerCutCheckInterval;
    }

    private void Update()
    {
        if (eventObjectManager.IsBanish(oneEventIndex))
        {
            ResetEvent(oneEventIndex);
        }
        HandleDamage();
        HandleRandomEvent();
    }

    private void HandleDamage()
    {
        if (!isHappening)
            StopDamage();
        else
            Damage();
    }

    private void HandleRandomEvent()
    {
        if (!start) return;
        if (!isHappening)
        {
            HandleEvent();
        }

        if (eventObjectManager.IsBanish(randomIndex))
        {
            ResetEvent();
        }

        HandlePowerCut();
    }

    public void TriggerOneEvent(int i)
    {
        bool canTriggerManyTime = eventObjectManager.eventObjects[i].hauntedObj.canTriggerManyTime;
        bool wasTriggered = eventObjectManager.eventObjects[i].hauntedObj.wasTriggered;
        if(canTriggerManyTime || !wasTriggered)
        {
            eventObjectManager.Activate(i);
            oneEventIndex = i;
            isHappening = true;
        }
    }

    private void RandomEvent()
    {
        isHappening = true;

        int range = eventObjectManager.count;
        randomIndex = Random.Range(0, range);

        bool canTriggerManyTime = eventObjectManager.eventObjects[randomIndex].hauntedObj.canTriggerManyTime;
        bool wasTriggered = eventObjectManager.eventObjects[randomIndex].hauntedObj.wasTriggered;
        if (canTriggerManyTime && wasTriggered)
        {
            RandomEvent();
        }
        else
        {
            eventObjectManager.Activate(randomIndex);
        }
    }

    private void ResetEvent()
    {
        isHappening = false;
        eventObjectManager.Deactivate();
    }
    private void ResetEvent(int i)
    {
        isHappening = false;
        eventObjectManager.Deactivate(i);
    }

    private void HandleEvent()
    {
        if (cdTime <= 0)
        {
            RandomEvent();
            cdTime = Random.Range(15, 30);
        }

        cdTime -= Time.deltaTime;
    }

    private void HandlePowerCut()
    {
        powerCutCooldown -= Time.deltaTime;

        if (powerCutCooldown <= 0f)
        {
            powerCutCooldown = powerCutCheckInterval;

            if (Random.value <= powerCutChance)
            {
                light.PowerOff();
            }
        }
    }

    private void Damage()
    {
        sanity.SanityDecrease(damage);
    }

    private void StopDamage()
    {
        sanity.SanityIncrease();
    }
}
