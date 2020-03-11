using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public SpriteRenderer SR;
    public Sprite checkPointOn, checkPointOff;

    // Start is called before the first frame update
    private void Start()
    {
        SR.sprite = checkPointOff;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CheckPointController.instance.DeactiveCheckPoints();
            SR.sprite = checkPointOn;
            CheckPointController.instance.correntCheckPointPos = transform.position;
        }
    }

    public void ResetCheckPoint()
    {
        SR.sprite = checkPointOff;
    }
}