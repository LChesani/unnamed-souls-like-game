using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HerosMemory : MonoBehaviour
{
    public string bossName;
    GameManager gm;

    private void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("BossFight");
                gm.activeBoss = bossName;
            }
        }
    }
}
