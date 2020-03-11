using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController instance;
    public Vector3 correntCheckPointPos;

    private CheckPoint[] checkPoints;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        checkPoints = FindObjectsOfType<CheckPoint>();
        correntCheckPointPos = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // to make all checkpoints deactived
    public void DeactiveCheckPoints()
    {
        for (int i = 0; i < checkPoints.Length; i++)
        {
            checkPoints[i].ResetCheckPoint();
        }
    }
}