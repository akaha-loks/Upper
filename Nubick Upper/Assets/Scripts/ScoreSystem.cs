using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private int Score;
    [SerializeField] private int BestScore;
    [SerializeField] private Text[] txt;
    private void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }
    private void Update()
    {
        Score = PlayerPrefs.GetInt("Score");
        BestScore = PlayerPrefs.GetInt("BestScore");
        txt[0].text = "" + Score;
        txt[1].text = "" + BestScore;

        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", Score);
        }
    }
}