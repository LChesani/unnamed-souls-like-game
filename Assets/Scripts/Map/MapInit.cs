using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInit : MonoBehaviour
{
    GameManager gm;
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gm.goEnemies = GameObject.FindWithTag("EnemyList");
        gm.enemies = gm.goEnemies.transform.GetComponentsInChildren<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
