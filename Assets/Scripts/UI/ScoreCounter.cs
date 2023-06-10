using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private int score;
    private int highScore;
    public TextMeshProUGUI[] scoreTexts;
    public SelectedSongData selectedSongData;

    private const int ScorePerSlice = 10;
    private const int ScorePerGreat = 20;
    private const int ScorePerPerfect = 30;

    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt(selectedSongData.songName + "Score", 0);
        UpdateScoreText();
    }

    public void IncreaseScore(int feedbackLevel)
    {
        int scoreToAdd = 0;

        switch (feedbackLevel)
        {
            case 0: // Good
                scoreToAdd = ScorePerSlice;
                break;
            case 1: // Great
                scoreToAdd = ScorePerPerfect;
                break;
            case 2: // Perfect
                scoreToAdd = ScorePerGreat;
                break;
            default: // Missed or unknown feedback level
                break;
        }

        score += scoreToAdd;
        UpdateScoreText();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(selectedSongData.songName + "Score", highScore);
        }
    }

    private void UpdateScoreText()
    {
        foreach (TextMeshProUGUI scoreText in scoreTexts)
        {
            scoreText.text = " " + score;
        }
    }
}
