using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
        audio.Stop();
    }
    public void QuitGame()
    {
        Application.Quit();
        audio.Stop();
    }
}
