using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeaath : MonoBehaviour
{
    public GameObject reward;

    [Range(0, 100)]
    public float rand;//物品掉落概率

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
            float i = Random.Range(0, 100);
            Debug.Log(i);
            if (i < rand)
            {
                Instantiate(reward, transform.position, transform.rotation);
            }
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}