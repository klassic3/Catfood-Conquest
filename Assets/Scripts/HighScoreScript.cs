using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{

    public float highScore;
    public Text highScoretext;

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
            highScore = data.highScore;
        }
        else
        {
            highScore = 0;
        }
        int roundedhighscore = (int)highScore;
        highScoretext.text ="HighScore: " + roundedhighscore.ToString();

    }
}
