using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    public ScoreManager()
    {
        InitScores();
    }

    public int CurrentScore
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            LastScore = currentScore;
        }
    }

    public int LastScore
    {
        get
        {
            return lastScore;
        }
        private set
        {
            lastScore = value;
            if (lastScore > bestScore)
            {
               // Debug.LogError("lastScore:" + lastScore + "HighestScore:" + BestScore);
                BestScore = lastScore;
                IsNewBestScore = true;
                //Debug.LogError("lastScore:" + lastScore + "HighestScore:" + BestScore);
            }
            SaveScores();
        }
    }
    public int BestScore
    {
        get
        {
            return bestScore;
        }

        private set
        {
            bestScore = value;
        }
    }


    public void InitScores()
    {
        IsNewBestScore = false;
        CurrentScore = 0;
        int lastScore = 0;
        int higheastScore = 0;
        if (PlayerPrefs.HasKey(PrefsLastScore))
        {
            lastScore = PlayerPrefs.GetInt(PrefsLastScore);
        }
        if (PlayerPrefs.HasKey(PrefsBestScore))
        {
            higheastScore = PlayerPrefs.GetInt(PrefsBestScore);
        }
        LastScore = lastScore;
        BestScore = higheastScore;
    }
    public void SaveScores()
    {
        PlayerPrefs.SetInt(PrefsLastScore, LastScore);
        PlayerPrefs.SetInt(PrefsBestScore, BestScore);
    }

    public void ClearScores()
    {
        if (PlayerPrefs.HasKey(PrefsLastScore))
        {
            PlayerPrefs.DeleteKey(PrefsLastScore);
        }
        if (PlayerPrefs.HasKey(PrefsBestScore))
        {
            PlayerPrefs.DeleteKey(PrefsBestScore);
        }
    }
    private int currentScore;
    private int lastScore;
    private int bestScore;
    public bool IsNewBestScore = false;
    private const string PrefsBestScore = "bestScore";
    private const string PrefsLastScore = "lastScore";
}
