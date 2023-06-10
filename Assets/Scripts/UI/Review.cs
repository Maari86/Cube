using UnityEngine;
using UnityEngine.UI;

public class Review : MonoBehaviour
{
    public Image[] starUIImages;
    public bool isGameCompleted = false;
    private FeedBackManager feedbackManager;

    private void Start()
    {
        feedbackManager = FindObjectOfType<FeedBackManager>();
    }

    public void UpdateStarRating()
    {
        int goodCount = feedbackManager.goodCount;
        int perfectCount = feedbackManager.perfectCount;
        int greatCount = feedbackManager.greatCount;
        int missedCount = feedbackManager.missedCount;

        // Deactivate all stars
        DeactivateAllStars();

        //One star by default if the player completes the level
        if (isGameCompleted)
        {
            EnableOneStar();

            //Two start if the missed count is less than destroyed count
            if (missedCount < (goodCount + greatCount + perfectCount))
            {
                EnableTwoStars();
            }

            if (missedCount < (greatCount + perfectCount) && (perfectCount > goodCount || greatCount > goodCount))
            {
                EnableThreeStars();
            }
        }
    }


    // Deactivate all star UI images
    private void DeactivateAllStars()
    {
        foreach (Image star in starUIImages)
        {
            star.fillAmount = 0f;
        }
    }

    // Enable one star UI image
    private void EnableOneStar()
    {
        starUIImages[0].fillAmount = 1f;
        if(PlayerPrefs.GetInt(feedbackManager.selectedSongData.songName,0) <= 0)
            PlayerPrefs.SetInt(feedbackManager.selectedSongData.songName,1);
    }

    // Enable two star UI images
    private void EnableTwoStars()
    {
        starUIImages[0].fillAmount = 1f;
        starUIImages[1].fillAmount = 1f;
        if (PlayerPrefs.GetInt(feedbackManager.selectedSongData.songName, 0) <= 1)
            PlayerPrefs.SetInt(feedbackManager.selectedSongData.songName, 2);
    }

    // Enable three star UI images
    private void EnableThreeStars()
    {
        starUIImages[0].fillAmount = 1f;
        starUIImages[1].fillAmount = 1f;
        starUIImages[2].fillAmount = 1f;
        if (PlayerPrefs.GetInt(feedbackManager.selectedSongData.songName, 0) <= 2)
            PlayerPrefs.SetInt(feedbackManager.selectedSongData.songName, 3);
    }
}
