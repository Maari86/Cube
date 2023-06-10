using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private FeedBackManager feedbackManager;
    public int feedbackLevel = -1;

    private void Start()
    {
        feedbackManager = FindObjectOfType<FeedBackManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collider"))
        {
            feedbackLevel = 3;
            feedbackManager.DisplayFeedbackMessage(3); // Pass the feedback level for "missed"
        }
        else if(other.CompareTag("SecondaryAttack") && feedbackLevel == -1)
        {
            feedbackLevel = 0;
        }
        else if (other.CompareTag("Attack") && feedbackLevel == 0)
        {
            feedbackLevel = 1;
        }
        else if(other.CompareTag("Attack") && feedbackLevel == -1)
        {
            feedbackLevel = 2;
        }
    }
}
