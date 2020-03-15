using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFulDown : MonoBehaviour
{
    public static PlayerFulDown instance;

    [Tooltip("The height when Player died ")]
    public float FullDownHeight;

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

    //Deal Fulling Down case
    public void DealFullDownDied()
    {
        if (PlayerController.instance.transform.position.y < FullDownHeight)
        {
            PlayerHealthController.instance.correntHealth = 0;
            UIController.instance.HeartInteraction();
            MusicController.instance.musicEffects[0].Stop();
            MusicController.instance.PlayAudio(11);
            LevelManager.instance.PlayerRebirthCo();
        }
    }
}