using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    // Other stuff
    public AudioClip brickHit, paddleHit, ballRespawn, mouseClick, mouseHover;

    // Background music
    public AudioClip menuAudio, levelAudio, bossAudio;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = menuAudio;
        audioSource.Play();
    }
    public void SettingAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
       // upVolume = true;
        //audioSource.volume = Mathf.Lerp(0f, 0.3f, Time.deltaTime * 10f);
        audioSource.Play();
    }
}
