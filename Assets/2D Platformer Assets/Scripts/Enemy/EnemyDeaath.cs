using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeaath : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StompBox"))
        {
            PlayerController.instance.ForceBack();
            EffectController.instance.PlayerDeathEffect(transform);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}