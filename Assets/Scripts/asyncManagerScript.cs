using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class asuncManagerScript : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject loadingscreen;
    [SerializeField] private GameObject levelscreen;

    [Header("Slider")]
    [SerializeField] private Slider loadingslider;


    public void LoadLevel(string level)
    {
        levelscreen.SetActive(false);
        loadingscreen.SetActive(true);

        //run async
        StartCoroutine(LoadLevelAsync(level));
    }

    IEnumerator LoadLevelAsync(string level)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(level);

        while (!loadOperation.isDone)
        {
            float loadValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingslider.value = loadValue;
            yield return null;
        }
    }
}
