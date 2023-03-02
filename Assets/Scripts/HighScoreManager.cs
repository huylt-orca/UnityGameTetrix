using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using System;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI[] timeTexts;
    public TextMeshProUGUI[] scoreTexts;

    private List<HighScoreEntry> highScores = new List<HighScoreEntry>();

    void Start()
    {

        //PlayerPrefs.SetString("HighScoreTime0"  , "03:00:00, 03/02/2023");
        //PlayerPrefs.SetInt("HighScoreScore0" , 300);
        //PlayerPrefs.SetString("HighScoreTime1" , "03:00:00, 04/02/2023");
        //PlayerPrefs.SetInt("HighScoreScore1" , 200);
        //PlayerPrefs.SetString("HighScoreTime2" , DateTime.Now.ToString("HH:mm:ss, dd/MM/yyyy"));
        //PlayerPrefs.SetInt("HighScoreScore2" , 100);

        // Load high scores from PlayerPrefs
        for (int i = 0; i < 3; i++)
        {
            string time = PlayerPrefs.GetString("HighScoreTime" + i, "...");
            int score = PlayerPrefs.GetInt("HighScoreScore" + i, 0);
            highScores.Add(new HighScoreEntry(time, score));
        }

        // Sort high scores by score
        highScores = highScores.OrderByDescending(o => o.score).ToList();

        // Update UI with high scores
        for (int i = 0; i < 3; i++)
        {
            if (i < highScores.Count)
            {
                timeTexts[i].text = highScores[i].time;
                scoreTexts[i].text = highScores[i].score.ToString();
            }
            else
            {
                timeTexts[i].text = "";
                scoreTexts[i].text = "";
            }
        }
    }

    public void AddHighScore(int score)
    {
        // Add new high score to list
        highScores.Add(new HighScoreEntry(DateTime.Now.ToString("HH:mm:ss, dd/MM/yyyy"), score));

        // Sort high scores by score
        highScores = highScores.OrderByDescending(o => o.score).ToList();

        // Remove lowest high score if there are more than 3
        if (highScores.Count > 3)
        {
            highScores.RemoveAt(3);
        }

        // Save high scores to PlayerPrefs
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetString("HighScoreTime" + i, highScores[i].time);
            PlayerPrefs.SetInt("HighScoreScore" + i, highScores[i].score);
        }

        // Update UI with high scores
        for (int i = 0; i < 3; i++)
        {
            if (i < highScores.Count)
            {
                timeTexts[i].text = highScores[i].time;
                scoreTexts[i].text = highScores[i].score.ToString();
            }
            else
            {
                timeTexts[i].text = "";
                scoreTexts[i].text = "";
            }
        }
    }
}
