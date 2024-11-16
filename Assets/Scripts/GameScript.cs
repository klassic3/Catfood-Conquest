using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public float distance;
    public GameObject cat;

    public GameObject pauseScreen;
    public Animator pauseanimation;
    public bool isPaused;

    public GameObject loadScreen;
    public bool isLoading;

    public GameObject poisonedScreen;
    public Text milkCounttextwithin;

    public int coinCount;
    public int internalCoinCount;
    public Text coinCounttext;

    public int catfoodCount;
    public Text catfoodCounttext;

   public GameObject Milkdisplay;
    public int milkCount;
    public Text milkCounttext;

    public float score;
    public float scoreincrement;
    public Text scoretext;


    public int posison;


    // Start is called before the first frame update
    void Start()
    {
        LoadCat();
        internalCoinCount = 0;
        coinCounttext.text = internalCoinCount.ToString();
        posison = 2;
        pauseScreen.SetActive(false);
        poisonedScreen.SetActive(false);
        isPaused = false;
        isLoading = true;
        hideMilk();
        scoreincrement = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused == false)
        {
            scoreincrement += 0.01f * Time.deltaTime;

            score +=  scoreincrement * Time.deltaTime;
            scoretext.text = ((int)score).ToString();
        }    
    }

    public void loadend()
    {
        loadScreen.SetActive(false);
        isPaused = false;
        isLoading=false;
    }
    public void moveRight()
    {
        if (isPaused == false)
        {
            if (posison != 3)
            {
                Vector3 direction = new Vector3(1.0f, 0.0f, 0.0f);
                cat.transform.Translate(direction * distance);
                posison += 1;
            }
        }
    }
    public void moveLeft()
    {
        if (isPaused == false)
        {
            if (posison != 1)
            {
                Vector3 direction = new Vector3(-1.0f, 0.0f, 0.0f);
                cat.transform.Translate(direction * distance);
                posison -= 1;
            }
        }
    }
    public void getCoin()
    {
        internalCoinCount += 1;
        coinCounttext.text = internalCoinCount.ToString();
    }
    public void getCatfood()
    {
        catfoodCount += 1;
        catfoodCounttext.text = catfoodCount.ToString();
    }

    public void getMilk()
    {
        milkCount += 1;
        milkCounttext.text = milkCount.ToString();
        milkCounttext.enabled = true;
        Milkdisplay.SetActive(true);
        Invoke("hideMilk", 1);
    }

    public void hideMilk()
    {
        milkCounttext.enabled = false;
        Milkdisplay.SetActive(false);
    }


    [ContextMenu("Save")]
    public void SaveCat()
    {
        coinCount += internalCoinCount;
        SaveScript.SaveCat(this);
    }
    [ContextMenu("Load")]
    public void LoadCat()
    {
        CatDataScript data = SaveScript.LoadCat();
        coinCount = data.coinCount;
        coinCounttext.text = coinCount.ToString();
        catfoodCount = data.catfoodCount;
        catfoodCounttext.text = catfoodCount.ToString();
        milkCount = data.milkCount;
        milkCounttext.text = milkCount.ToString();
    }
    [ContextMenu("Reset")]
    public void ResetCat()
    {
        coinCount = 0;
        coinCounttext.text = coinCount.ToString();
        SaveScript.SaveCat(this);
    }

    public void Poisoned()
    {
        poisonedScreen.SetActive(true);
        milkCounttextwithin.text = milkCount.ToString();
        isPaused = true;
    }
    public void Continue()
    {
        milkCount -= 1;
        poisonedScreen.SetActive(false);
        isPaused = false;
    }
    public void GIveup()
    {
        SaveCat();
        SceneManager.LoadScene("TitleScene");
    }

    [ContextMenu("Pause")]
    public void Pause()
    {
        if (poisonedScreen.activeSelf==false)
        {
            pauseScreen.SetActive(true);
            isPaused = true;
        }

    }

    [ContextMenu("Resume")]
    public void ResumeAnim()
    {
        pauseanimation.SetTrigger("pauseclose");
        Invoke("Resume", 0.4f);
    }
    public void Resume()
    {
        pauseScreen.SetActive(false);
        isPaused = false;
    }
    public void Quit()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
