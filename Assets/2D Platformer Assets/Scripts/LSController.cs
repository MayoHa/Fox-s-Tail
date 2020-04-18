using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSController : MonoBehaviour
{
    public Transform correntPoint;

    public float moveSpeed;

    private int levelID;

    // Start is called before the first frame update
    private void Start()
    {
        levelID = correntPoint.GetComponent<LPController>().levelID;
        transform.position = correntPoint.position;
        //transform.position = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        LSMove(KeyCode.W, correntPoint.GetComponent<LPController>().upPoint);
        LSMove(KeyCode.A, correntPoint.GetComponent<LPController>().leftPoint);
        LSMove(KeyCode.D, correntPoint.GetComponent<LPController>().rightPoint);
        LSMove(KeyCode.S, correntPoint.GetComponent<LPController>().downPoint);
        EnterLevel();
    }

    private void LSMove(KeyCode keyCode, Transform levelPoint)
    {
        if (Input.GetKeyDown(keyCode) && levelPoint != null)
        {
            transform.position = levelPoint.position;
            correntPoint = levelPoint;
            levelID = correntPoint.GetComponent<LPController>().levelID;
        }
    }

    private void EnterLevel()
    {
        if (Input.GetKeyDown(KeyCode.Return) && correntPoint.GetComponent<LPController>().isLevel)
        {
            if (levelID <= SceneManager.sceneCountInBuildSettings - 2 && levelID != 0)
                SceneManager.LoadScene(correntPoint.GetComponent<LPController>().levelID);
        }
    }
}