using UnityEngine;
using TMPro;

public class SentenceDisplay : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string[] sentences;

    private void Start()
    {
        DisplayRandomSentence();
    }

    public void DisplayRandomSentence()
    {
        if (sentences.Length > 0)
        {
            int randomIndex = Random.Range(0, sentences.Length);

            string randomSentence = sentences[randomIndex];
            // Display the random sentence in the TextMeshProUGUI component
            textMeshPro.text = randomSentence;
        }
    }
}
