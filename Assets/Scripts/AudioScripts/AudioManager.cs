using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private const int SAMPLE_SIZE = 256;

    public float preFreqN = 0f;

    public float pitchValue;

    public SelectedSongData selectedSongData;
    public ObjectSpawner objectSpawner;
    public Review review;
    public int cubePitchMin = 400;
    public float pitchDelay = 0.3f;
    public AudioSource gamePlayAudio;
    public float startAudioAfter = 6f;

    private float lastPitchTime = 0f;

    public Image uiImage;

    private AudioSource source;
    private float[] spectrum;
    private float sampleRate;
    List<List<int>> pitchOfTheSong = new List<List<int>>();
    System.Random rnd = new System.Random();

    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1f;

        source = GetComponent<AudioSource>();
        spectrum = new float[SAMPLE_SIZE];

        string songLocation = selectedSongData.songLocation;
        AudioType songFormat = selectedSongData.songFormat;

        source.clip = new WWW("file://" + songLocation).GetAudioClip(false, true, songFormat);
        source.Play();
        sampleRate = AudioSettings.outputSampleRate;

        gamePlayAudio.clip = new WWW("file://" + songLocation).GetAudioClip(false, true, songFormat);
        Invoke(nameof(PlayGamePlayAudio), startAudioAfter);
    }

    public void PlayGamePlayAudio()
    {
        // Debug.Log("length of the song: " + gamePlayAudio.clip.length);
        gamePlayAudio.Play();
        float clipLength = gamePlayAudio.clip.length;
        Invoke(nameof(GameCompleted), startAudioAfter + clipLength);
    }

    public void GameCompleted()
    {
        review.isGameCompleted = true;
        EnableUIImage();
    }

    private void FixedUpdate()
    {
        AnalyzeSound();
    }


    public void AnalyzeSound()
    {
        int i = 0;
        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        // Find pitch
        float maxV = 0;
        var maxN = 0;
        for (i = 0; i < spectrum.Length - 1; i++)
        {
            //Debug.Log("spectrum: " + spectrum[i]);
            if ((spectrum[i] > maxV))
            {
                maxV = spectrum[i];
                maxN = i;
            }
        }
        //Debug.Log("MaxN: " + maxN);
        float freqN = maxN;

        //Adjusting the Min. Pitch value
        if (freqN <= 5.0f)
            cubePitchMin = 100;
        else if (freqN > 5.0f && freqN <= 15.0f)
            cubePitchMin = 200;
        else
            cubePitchMin = 300;

        if (preFreqN <= 2f && freqN <= 2f)
            cubePitchMin = 40;
        else if (preFreqN > 3f && preFreqN <= 5f && freqN <= 5f)
            cubePitchMin = 50;

        preFreqN = freqN;

        pitchValue = freqN * (sampleRate / 2) / SAMPLE_SIZE;

        int path = GetPathForPitch(pitchValue);
        if (path != 0 && Time.time - lastPitchTime >= pitchDelay)
        {
            int boxIndex = (path == 0) ? 0 : rnd.Next(2);
            objectSpawner.SpawnObjects(path, boxIndex);
            if(Random.Range(0f,1f) > 0.8f)
            {
                objectSpawner.SpawnObjects(path + (Random.Range(0f, 1f) > 0.5f ? -1 : 1), 2); //obstacle index is 2
            }
            else if(Random.Range(0f,1f) > 0.8f)
            {
                objectSpawner.SpawnObjects(path + (Random.Range(0f, 1f) > 0.5f ? -1 : 1), 3); //Collectable Gem index is 3
            }
            lastPitchTime = Time.time;
        }
    }

    private int GetPathForPitch(float pitch)
    {
        if (pitch > cubePitchMin)
        {
            System.Random tile = new System.Random();
            return (tile.Next(50)) % 4 + 1;     // This should work with 5 but not working, temp fix
        }
        return 0;
    }

    public void EnableUIImage()
    {
        source.Stop();
        gamePlayAudio.Stop();
        review.UpdateStarRating();
        uiImage.gameObject.SetActive(true);
    }
}
