using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject levelCompleted;

    public GameObject fadeOut;

    public Scene thisScene;

    private void Start()
    {
        levelCompleted.SetActive(false);
        thisScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(thisScene.buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelCompleted.SetActive(true);
            PlayerController.instance.isInput = false;
            PlayerController.instance.LevelEndRun();
            CameraController.instance.isFollow = false;
            StartCoroutine(CompletedFadeOut());
        }
    }

    private IEnumerator CompletedFadeOut()
    {
        //MusicController.instance.musicEffects[0].volume = Mathf.MoveTowards(MusicController.instance.musicEffects[0].volume, 0, 0.75f);
        MusicController.instance.musicEffects[0].Stop();
        MusicController.instance.PlayMusic(1);
        yield return new WaitForSeconds(0.5f);
        fadeOut.SetActive(true);
        UIFadeOut.instance.FadeToBlack();

        yield return new WaitForSeconds(0.3f);
        levelCompleted.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneTurn();
    }

    private void SceneTurn()
    {
        if (thisScene.buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(thisScene.buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}