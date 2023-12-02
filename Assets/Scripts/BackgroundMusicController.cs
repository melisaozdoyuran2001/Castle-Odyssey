using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // Call this method when the player dies
    public void StopBackgroundMusic()
    {
        // Stop the background music
        audioSource.Stop();
    }
}
