using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitForRebirth;

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

    public void PlayerRebirthCo()
    {
        StartCoroutine(PlayerRebirth());
    }

    // to make the Player rebirth at the checkpoint
    private IEnumerator PlayerRebirth()
    {
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitForRebirth);
        PlayerController.instance.gameObject.SetActive(true);
        /* to avoid player transform into hurt state when he respawns */
        PlayerController.instance.isKnockBack = false;
        PlayerHealthController.instance.isInvinvible = true;

        PlayerController.instance.transform.position = CheckPointController.instance.correntCheckPointPos;

        PlayerHealthController.instance.correntHealth = PlayerHealthController.instance.maxHealth;
        UIController.instance.RefreshUI();
    }
}