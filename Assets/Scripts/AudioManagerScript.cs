using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip bgm_for_main;
    public AudioClip coin;
    public AudioClip foodgrab;

    private void Start()
    {
        musicSource.clip = bgm_for_main;
        musicSource.Play();
       //for switching
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        /*if(sceneName== "GameOverScene")
        {
            
            PlaySFX(deathsfx);

        }*/

    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);

    }
}
