using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiscripts : MonoBehaviour
{
    public GameObject howtoplayscreen;
    public GameObject TitleScreen;
    public GameObject Title;
    public int coinCount;
    public Text coinCounttext;
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
        coinCount = data.coinCount;
        coinCounttext.text = coinCount.ToString();
    }
    public void Play()
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("MoonScene");
    }
    public void ExitButtton()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void howtoplayButton()
    {
        SceneManager.LoadScene("howtoplay");
    }

    public void BackButton()
    {

        SceneManager.LoadScene("TitleScene");
    }
    public void backbutton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
