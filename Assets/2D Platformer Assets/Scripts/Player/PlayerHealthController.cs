using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance; // static this class for quickly use by other classes

    public int maxHealth = 6, correntHealth;

    private float invincibleTime = 2f;
    private Color colorAlpha;

    [HideInInspector]
    public bool isInvinvible;

    private int targetAlpha;
    private Rigidbody2D rb;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        correntHealth = GameData.instance.playerHealthCount;
        colorAlpha = gameObject.GetComponent<SpriteRenderer>().color;
        rb = GetComponent<Rigidbody2D>();
        isInvinvible = false;
        targetAlpha = 0;
    }

    private void Update()
    {
        //invinvible Player time
        Invinvible();
        if (isInvinvible)
        {
            invincibleTime -= Time.deltaTime;
            if (invincibleTime < 0)
            {
                isInvinvible = false;
                invincibleTime = 2f;
            }
        }
    }

    // deal Player's health
    public void DealDamage(int attack)
    {
        if (!isInvinvible)
        {
            for (int i = 0; i < attack; i++)
            {
                GameData.instance.playerHealthCount--;
            }
            UIController.instance.HeartInteraction();
            MusicController.instance.PlayAudio(9);
            isInvinvible = true;
            PlayerController.instance.isKnockBack = true;
            //ForceBack();
        }

        if (GameData.instance.playerHealthCount <= 0)
        {
            GameData.instance.playerHealthCount = 0;//to ensure it exceed 0
            EffectController.instance.PlayerDeathEffect(transform);
            MusicController.instance.musicEffects[0].Stop();
            LevelManager.instance.PlayerRebirthCo();
            //StartCoroutine(PlayerRebirth());
            //PlayerRebirth();
        }
    }

    //to controll the alpha of player
    public void Invinvible()
    {
        if (isInvinvible && invincibleTime > 0)
        {
            colorAlpha.a = Mathf.MoveTowards(colorAlpha.a, targetAlpha, Time.deltaTime * 8f);
            if (colorAlpha.a == 0)
            {
                targetAlpha = 1;
            }
            else if (colorAlpha.a == 1)
            {
                targetAlpha = 0;
            }
        }
        else if (!isInvinvible)
        {
            colorAlpha.a = 1;
        }

        gameObject.GetComponent<SpriteRenderer>().color = colorAlpha;
    }
}