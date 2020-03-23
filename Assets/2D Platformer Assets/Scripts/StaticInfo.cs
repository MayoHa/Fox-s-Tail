using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInfo : MonoBehaviour
{
    // Start is called before the first frame update

    public static int Gem;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Gem = LevelManager.instance.GemCount;
    }
}