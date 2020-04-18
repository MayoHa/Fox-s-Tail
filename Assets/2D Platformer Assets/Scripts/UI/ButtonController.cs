using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void StartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void HelperButton()
    {
        SceneManager.LoadScene("Helper");
    }

    public void ReturnButton()
    {
        SceneManager.LoadScene(0);
    }
}