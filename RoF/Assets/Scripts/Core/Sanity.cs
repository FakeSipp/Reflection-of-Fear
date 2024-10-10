using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Sanity : MonoBehaviour
{
    [Header("Manager")]
    private UIManager playerUI;

    [Header("Sanity Value")] // HEADER FOR SANITY VALUES IN INSPECTOR
    public float maxSanity = 100; // MAXIMUM SANITY VALUE
    public float sanity; // CURRENT SANITY VALUE

    [Header("Sanity Bar")] // HEADER FOR SANITY BAR IN INSPECTOR
    public Slider slider; // UI SLIDER THAT REPRESENTS SANITY

    private void Start()
    {
        playerUI = FindAnyObjectByType<UIManager>();
        slider = playerUI.sanityBar;

        // INITIALIZE SANITY TO MAXIMUM VALUE AT GAME START
        sanity = maxSanity;

        // SET THE SANITY BAR TO MAXIMUM VALUE AT GAME START
        SetMaxSanity();
    }

    private void Update()
    {
        // UPDATE THE SANITY BAR TO REFLECT THE CURRENT SANITY
        SetSanity();

        // ENSURE SANITY DOES NOT EXCEED MAXIMUM SANITY VALUE
        if (sanity >= maxSanity) sanity = maxSanity;

        // CHECK IF SANITY IS ZERO OR LESS, AND IF SO, TRIGGER THE DEAD FUNCTION
        if (sanity <= 0) Dead();
    }

    private void Dead()
    {
        // ENABLE VIDEO PLAYER AND PLAY THE JUMPSCARE VIDEO
        RawImage videoPlayer = playerUI.videoPlayer;
        VideoPlayer video = videoPlayer.transform.Find("Jumpscare").GetComponent<VideoPlayer>();
        videoPlayer.enabled = true;
        video.enabled = true;

        // SUBSCRIBE TO THE EVENT THAT IS TRIGGERED WHEN THE VIDEO ENDS
        video.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer videoPlayer)
    {
        // LOAD SCENE 0 WHEN THE VIDEO ENDS
        SceneManager.LoadScene(0);
    }

    public void SanityDecrease(float damage)
    {
        // DECREASE SANITY BASED ON DAMAGE AND TIME
        sanity -= damage * Time.deltaTime;
    }

    public void SanityIncrease(float sanityBoost = 1)
    {
        // INCREASE SANITY BASED ON A BOOST AMOUNT AND TIME IF IT'S BELOW MAX SANITY
        if (sanity < maxSanity)
        {
            sanity += sanityBoost * Time.deltaTime;
        }
    }

    private void SetMaxSanity()
    {
        // SET THE MAXIMUM VALUE FOR THE SANITY SLIDER
        slider.maxValue = maxSanity;

        // INITIALIZE THE SLIDER'S VALUE TO FULL SANITY
        slider.value = maxSanity;
    }

    private void SetSanity()
    {
        // UPDATE THE SANITY SLIDER TO MATCH THE CURRENT SANITY VALUE
        slider.value = sanity;
    }
}
