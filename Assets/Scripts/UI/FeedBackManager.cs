using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeedBackManager : MonoBehaviour
{
    [SerializeField]
    private Image missedImage, goodImage, perfectImage, greatImage;

    public float displayDuration = 2f;

    public int missedCount = 0;
    public int goodCount = 0;
    public int perfectCount = 0;
    public int greatCount = 0;

    public TMP_Text songNameText;
    public Text missedCountText;
    public Text goodCountText;
    public Text perfectCountText;
    public Text greatCountText;

    public SelectedSongData selectedSongData;

    public delegate void FeedbackUpdateAction();

    private void Start()
    {
        missedImage.enabled = false;
        goodImage.enabled = false;
        greatImage.enabled = false;
        perfectImage.enabled = false;

        songNameText.text = selectedSongData.songName;
    }
    // ...

    public void DisplayFeedbackMessage(int feedbackLevel)
    {
        StartCoroutine(DisplayFeedbackCoroutine(feedbackLevel));

        // Call the IncreaseScore method in ScoreCounter script with the feedbackLevel parameter
        FindObjectOfType<ScoreCounter>().IncreaseScore(feedbackLevel);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cubes"))
        {
            DisplayFeedbackMessage(3); // Display "missed" feedback
        }
    }

    private System.Collections.IEnumerator DisplayFeedbackCoroutine(int feedbackLevel)
    { 
        string countText;

        switch (feedbackLevel)
        {
            case 0:
                DisableAllFeedbacks();
                goodImage.enabled = true;
                goodCount++;
                countText = "Good: " + goodCount.ToString();
                break;
            case 1:
                DisableAllFeedbacks();
                greatImage.enabled = true;
                greatCount++;
                countText = "Great: " + greatCount.ToString();
                break;
            case 2:
                DisableAllFeedbacks();
                perfectImage.enabled = true;
                perfectCount++;
                countText = "Perfect: " + perfectCount.ToString();
                break;
            default:
                if(!perfectImage.enabled && !greatImage.enabled && !goodImage.enabled)
                {
                    missedImage.enabled = true;
                }
                missedCount++;
                countText = "Missed: " + missedCount.ToString();
                break;
        }

        // Update the appropriate count text element
        if (feedbackLevel == 0)
            goodCountText.text = countText;
        else if (feedbackLevel == 1)
            greatCountText.text = countText;
        else if (feedbackLevel == 2)
            perfectCountText.text = countText;
        else
            missedCountText.text = countText;

        yield return new WaitForSeconds(displayDuration);

        if (feedbackLevel == 0)
            goodImage.enabled = false;
        else if (feedbackLevel == 1)
            greatImage.enabled = false;
        else if (feedbackLevel == 2)
            perfectImage.enabled = false;
        else
            missedImage.enabled = false;
    }

    void DisableAllFeedbacks()
    {
        goodImage.enabled = false;
        greatImage.enabled = false;
        perfectImage.enabled = false;
        missedImage.enabled = false;
    }

    private int CalculateFeedbackLevelIndex()
    {
        int feedbackLevelIndex = 0;

        return feedbackLevelIndex;
    }
}
