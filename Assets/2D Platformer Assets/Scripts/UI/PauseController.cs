using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public static PauseController instance;

    [HideInInspector]
    public bool isPaused = false;

    public GameObject pausePanel;

    private void Awake()
    {
        pausePanel.SetActive(false);
        isPaused = false;
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    //Pause
    public void Pause()
    {
        Time.timeScale = 0f;
        MusicController.instance.musicEffects[0].Pause();
        isPaused = true;
        pausePanel.SetActive(true);
    }

    //Resume
    public void Resume()
    {
        pausePanel.SetActive(false);
        MusicController.instance.musicEffects[0].Play();
        isPaused = false;
        Time.timeScale = 1f;
    }

    //to the levelSelect Menu
    public void LevelSelect()
    {
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}