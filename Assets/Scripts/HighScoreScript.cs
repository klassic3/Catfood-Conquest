using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{

    public float MoonhighScore;
    public Text MoonhighScoretext;

    public float MarshighScore;
    public Text MarshighScoretext;


    // Start is called before the first frame update
    void Start()
    {
        LoadCat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCat()
    {
        CatDataScript data = SaveScript.LoadCat();
        if (data != null)
        {
            MoonhighScore = data.MoonhighScore;
            MarshighScore = data.MarshighScore;
        }
        else
        {
            MoonhighScore = 0;
            MarshighScore= 0;
        }
        int roundedMoonhighscore = (int)MoonhighScore;
        MoonhighScoretext.text ="HighScore: " + roundedMoonhighscore.ToString();
        int roundedMarshighscore = (int)MarshighScore;
        MarshighScoretext.text = "HighScore: " + roundedMarshighscore.ToString();
    }
}
