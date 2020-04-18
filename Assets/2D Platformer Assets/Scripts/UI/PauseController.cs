using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public static PauseController instance;

    [HideInInspector]
    public bool isPaused = false;

    public GameObject fadeOutPanel;
    public GameObject pausePanel;

    //private int keyCount;

    private void Awake()
    {
        pausePanel.SetActive(false);
        isPaused = false;
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        //keyCount = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !fadeOutPanel.activeSelf && !isPaused)
        {
            //keyCount++;
            Pause();
            Debug.Log("getKey");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Resume();
            Debug.Log("setKey");
        }
    }

    //Pause
    public void Pause()
    {
        Time.timeScale = 0f;
        MusicController.instance.musicEffects[0].Pause();
        isPaused = true;
        pausePanel.SetActive(true);
        //if (Input.GetKeyDown(KeyCode.Escape))
    }

    //Resume
    public void Resume()
    {
        Time.timeScale = 1f;
        //keyCount++;
        pausePanel.SetActive(false);
        MusicController.instance.musicEffects[0].Play();
        isPaused = false;
    }

    //to the levelSelect Menu
    public void LevelSelect()
    {
    }

    public void MainMenu()
    {
        //keyCount++;
        SceneManager.LoadScene(0);
    }
}