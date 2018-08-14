using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject camOrtho, camPersp;

    public Toggle oToggle, pToggle;

    // Music Slider
    public Slider musicSlider;

    AudioManager getAudioManager;

    private void Awake()
    {
        getAudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Use this for initialization
    void Start()
    {
        camOrtho.SetActive(true);
        camPersp.SetActive(false);

        musicSlider.value = 0.3f;

        getAudioManager.audioSource.volume = musicSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (oToggle.isOn)
        {
            camOrtho.SetActive(true);
            camPersp.SetActive(false);
        }
        else if (pToggle.isOn)
        {
            camOrtho.SetActive(false);
            camPersp.SetActive(true);
        }

        getAudioManager.audioSource.volume = musicSlider.value;
    }
}
