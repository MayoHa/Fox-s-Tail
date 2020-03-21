using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeOut : MonoBehaviour
{
    public static UIFadeOut instance;

    public Image image;

    [Range(0.5f, 1f)]
    public float fadeSpeed;

    private bool fadeToBlack, fadeToAlpha;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        fadeToAlpha = true;
        fadeToBlack = false;
        StartCoroutine(SceneStart());
    }

    // Update is called once per frame
    private void Update()
    {
        if (fadeToBlack)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.MoveTowards(image.color.a, 1, fadeSpeed * Time.deltaTime));
            if (image.color.a == 1)
            {
                fadeToBlack = false;
            }
        }

        if (fadeToAlpha)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.MoveTowards(image.color.a, 0, fadeSpeed * Time.deltaTime));
            if (image.color.a == 0)
            {
                fadeToAlpha = false;
            }
        }
    }

    public void FadeToBlack()
    {
        fadeToBlack = true;
        fadeToAlpha = false;
    }

    public void FadeToAlpha()
    {
        fadeToBlack = false;
        fadeToAlpha = true;
    }

    public IEnumerator SceneStart()
    {
        yield return new WaitForSeconds(fadeSpeed);
        MusicController.instance.PlayMusic(0);
    }
}