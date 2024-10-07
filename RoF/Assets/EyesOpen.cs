using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EyesOpen : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;

    private PlayerWordsManager wordsManager;

    public float decreaseSpeed = 0.1f;

    private void Awake()
    {
        wordsManager = FindAnyObjectByType<PlayerWordsManager>();
        postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.enabled = true;

        if (postProcessVolume.profile.TryGetSettings(out vignette))
        {
            vignette.intensity.value = 0.5f;
        }

        wordsManager.StartGameText();
    }

    private void Update()
    {
        if (vignette != null && vignette.intensity.value > 0)
        {
            vignette.intensity.value -= decreaseSpeed * Time.deltaTime;
            vignette.intensity.value = Mathf.Max(vignette.intensity.value, 0);
        }
    }
}
