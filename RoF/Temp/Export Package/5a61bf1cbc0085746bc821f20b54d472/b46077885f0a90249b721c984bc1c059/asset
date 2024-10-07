using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    [Header("Manager")]
    private InputManager input;

    [Header("Flashlight Value")]
    public float decreaseSpeed = 0.5f;
    private Light flashLight;
    private bool isUsing = false;

    [Header("Flashlight Bar")]
    public Slider slider;

    [Header("Flashlight Parameters")]
    private float maxBattery = 100;
    private float currentBattery;
    private bool canUse = true;

    private void Awake()
    {
        #region Get Manager
        input = GameObject.Find("InputManager").GetComponent<InputManager>();  
        #endregion
    }

    private void Start()
    {
        currentBattery = maxBattery;
        flashLight = GetComponent<Light>();
        SetMaxBattery();
    }

    private void Update()
    {
        if (input.FlashlightInput && canUse)
        {
            ToggleFlashlight();
            input.FlashlightInput = false;
        }

        if (isUsing)
        {
            currentBattery -= decreaseSpeed * Time.deltaTime;
            currentBattery = Mathf.Clamp(currentBattery, 0, maxBattery); 
        }

        if (currentBattery <= 0)
        {
            flashLight.enabled = false;
            canUse = false;
            isUsing = false;
        }

        SetBattery();
    }

    private void ToggleFlashlight()
    {
        isUsing = !isUsing;
        flashLight.enabled = isUsing;
    }

    private void SetMaxBattery()
    {
        slider.maxValue = maxBattery;
        slider.value = maxBattery;
    }

    private void SetBattery()
    {
        slider.value = currentBattery;
    }
}
