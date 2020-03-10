using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    //[Tooltip("ensure to set by order")]
    //public Image[] images;

    //[Tooltip("ensure to set by order")]
    //public Sprite[] sprites;

    public Image heart1, heart2, heart3;
    public Sprite heart_Empty, heart_Half, heart_Full;

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

    // to make UI heart interactive with player
    public void HeartInteraction()
    {
        switch (PlayerHealthController.instance.correntHealth)
        {
            case 1:
                heart1.sprite = heart_Half;
                heart2.sprite = heart_Empty;
                heart3.sprite = heart_Empty;
                break;

            case 2:
                heart1.sprite = heart_Full;
                heart2.sprite = heart_Empty;
                heart3.sprite = heart_Empty;
                break;

            case 3:
                heart1.sprite = heart_Full;
                heart2.sprite = heart_Half;
                heart3.sprite = heart_Empty;
                break;

            case 4:
                heart1.sprite = heart_Full;
                heart2.sprite = heart_Full;
                heart3.sprite = heart_Empty;
                break;

            case 5:
                heart1.sprite = heart_Full;
                heart2.sprite = heart_Full;
                heart3.sprite = heart_Half;
                break;

            case 6:
                heart1.sprite = heart_Full;
                heart2.sprite = heart_Full;
                heart3.sprite = heart_Full;
                break;

            default:
                heart1.sprite = heart_Empty;
                heart2.sprite = heart_Empty;
                heart3.sprite = heart_Empty;
                break;
        }
    }
}