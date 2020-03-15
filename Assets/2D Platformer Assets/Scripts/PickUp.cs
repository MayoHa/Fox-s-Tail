using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public static PickUp instance;

    public bool isGem;
    public bool isCherry;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        UIController.instance.GemsAmountDisplay();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUpALL();
        }
    }

    //pick up rewards
    public void PickUpALL()
    {
        if (isGem)
        {
            LevelManager.instance.GemCount++;
            UIController.instance.GemsAmountDisplay();
            EffectController.instance.CollectEffect(transform);
            MusicController.instance.PlayAudio(6);
            Destroy(gameObject);
        }

        if (isCherry)
        {
            if (!(PlayerHealthController.instance.correntHealth == PlayerHealthController.instance.maxHealth))
            {
                PlayerHealthController.instance.correntHealth++;
                UIController.instance.HeartsAmountDisplay();
                EffectController.instance.CollectEffect(transform);
                MusicController.instance.PlayAudio(7);
                Destroy(gameObject);
            }
        }
    }
}