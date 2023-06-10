using UnityEngine;

public class GameMenuAudio : MonoBehaviour
{
    public SelectedSongData selectedSongData;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        /*if (selectedSongData != null && selectedSongData.selectedSong != null)
        {
            audioSource.clip = selectedSongData.selectedSong;
            audioSource.Play();
        }*/
    }
}
