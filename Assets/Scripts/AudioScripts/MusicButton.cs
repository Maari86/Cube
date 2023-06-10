using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public AudioClip musicClip; // Drag and drop the audio clip for each button in the Inspector
    private Button button;
    private AudioSource audioSource;
    private static AudioSource activeAudioSource; // Store the currently playing audio source

    private void Start()
    {
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
    }

    public void PlayMusic()
    {
        if (activeAudioSource != null && activeAudioSource != audioSource)
        {
            activeAudioSource.Stop(); 
        }

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            activeAudioSource = audioSource; // Set the currently playing audio source
        }
        else
        {
            audioSource.Stop();
            activeAudioSource = null; // Reset the currently playing audio source
        }
    }
}
