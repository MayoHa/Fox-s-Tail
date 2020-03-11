using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform farBG, midBG;
    public float minHeight, maxHeight;

    private Vector3 lastPos;

    // Start is called before the first frame update
    private void Start()
    {
        lastPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        Vector3 AmountBetweenFrame = transform.position - lastPos;

        //parallax
        farBG.position += AmountBetweenFrame;
        midBG.position += AmountBetweenFrame * 0.5f;

        lastPos = transform.position;
    }
}