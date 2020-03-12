using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public static EffectController instance;
    public GameObject collectEffect, playerDeathEffect;

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

    public void CollectEffect(Transform transform)
    {
        Instantiate(collectEffect, transform.position, transform.rotation);
    }

    public void PlayerDeathEffect(Transform transform)
    {
        Instantiate(playerDeathEffect, transform.position, transform.rotation);
    }
}