using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEventManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private SmallStrangeObject obj;

    [Header("Event Parameters")]
    [SerializeField] private bool start;
    [SerializeField] private float damage;
    [SerializeField] private bool isHappening;

    [Header("Player Parameters")]
    private Sanity sanity;

    public InputManager input;

    private void Awake()
    {
        input = FindAnyObjectByType<InputManager>();
        obj = transform.GetComponent<SmallStrangeObject>();
        sanity = FindAnyObjectByType<Sanity>();
    }

    private void Update()
    {
        if (!start) return;
        if (!isHappening)
        {
            StopDamage();
        }
        else
        {
            EventHandler();
            Damage();
        }

        if (input.FlashlightInput)
        {
            ResetEvent();
        }

    }

    private void EventHandler()
    {
        isHappening = true;
        obj.Activate();
    }

    private void ResetEvent()
    {
        isHappening = false;
        obj.Deactivate();
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
