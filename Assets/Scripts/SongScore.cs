using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SongScore : MonoBehaviour
{
    public Image[] starImagesFilled = new Image[3];
    public Text songTitleText;
    public TextMeshProUGUI highScoreText;
    void Start()
    {
        //Debug.Log(songTitleText.text + "Score");
        int highScore = PlayerPrefs.GetInt(songTitleText.text+"Score", 0);
        highScoreText.text = "High Score: " + highScore;
        int songStarValue = PlayerPrefs.GetInt(songTitleText.text,0);

        for(int i=0;i< starImagesFilled.Length; i++)
        {
            starImagesFilled[i].enabled = false;
            if (songStarValue >= i+1)
            {
                starImagesFilled[i].enabled = true;
            }
        }

    }
}
