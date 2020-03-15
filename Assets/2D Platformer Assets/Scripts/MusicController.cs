using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    public AudioSource[] audioEffects;
    public AudioSource[] musicEffects;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void PlayAudio(int value)
    {
        audioEffects[value].Stop();
        audioEffects[value].pitch = Random.Range(.8f, 1.1f);
        audioEffects[value].Play();
    }

    public void PlayMusic(int value)
    {
        musicEffects[value].Stop();
        musicEffects[value].Play();
    }
}