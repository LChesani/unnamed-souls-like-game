using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UniGLTF;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] MainCharacter player;
    [SerializeField] GameObject goEnemies;
    Enemy[] enemies;
    void Start()
    {
        enemies = goEnemies.transform.GetComponentsInChildren<Enemy>();
        player.OnReset += resetCall;
    }

    public void resetCall()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.parent.gameObject.SetActive(true);
            enemies[i].resetHp();
            enemies[i].transform.position = enemies[i].initialPos;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(player.getHP().x <= 0.0f)
        {
            player.resetChk(true);
            resetCall();
        }
        
    }
}
