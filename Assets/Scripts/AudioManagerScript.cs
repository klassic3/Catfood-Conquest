using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip bgm_for_main;
    public AudioClip coin;
    public AudioClip foodgrab;
    public AudioClip lobby_music;
    public AudioClip buttonClick;

    public static AudioManagerScript Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        ////for switching
        //// Create a temporary reference to the current scene.
        //Scene currentScene = SceneManager.GetActiveScene();

        //// Retrieve the name of this scene.
        //string sceneName = currentScene.name;

        //if (sceneName == "MoonScene")
        //{

        //    musicSource.clip = bgm_for_main;
        //    musicSource.Play();

        //}
        //else
        //{
        //    musicSource.clip = lobby_music;
        //    musicSource.Play();

        //}
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusicForCurrentScene();
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void PlayMusicForCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "MoonScene")
        {
            if (musicSource.clip != bgm_for_main)
            {
                musicSource.clip = bgm_for_main;
                musicSource.Play();
            }
        }
        else
        {
            if (musicSource.clip != lobby_music)
            {
                musicSource.clip = lobby_music;
                musicSource.Play();
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForCurrentScene();
    }
    public void PlaySFX(AudioClip clip)
    {
        if (SFXSource.isPlaying)
        {
            SFXSource.Stop();
        }
        SFXSource.PlayOneShot(clip);

    }
    public void PlayButtonClickSFX()
    {
        PlaySFX(buttonClick);
    }
}
