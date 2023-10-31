using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float maxHp;
    [SerializeField] public float damage;
    [SerializeField] public MainCharacter player;
    [SerializeField] EnemyWeapon weapon;
    [SerializeField] int blood;
    [SerializeField] public string bossName;
    public Vector3 initialPos;
    public float hp;
    public float dmgDelay = 0.0f;
    private void OnTriggerEnter(Collider collision)
    {
        if(dmgDelay <= 0.0f && collision.gameObject.tag == "Weapon" && player.attacking)
        {
            dmgDelay = 0.5f;
            hp -= player.calculateDamage();
        }
    }

    public void resetHp()
    {
        hp = maxHp;
    }

    private void Start() { 
        hp = maxHp;
        initialPos = transform.position;
    }

    void Update()
    {
        weapon.damage = damage;
        if (dmgDelay >= 0.0f)
        {
            dmgDelay -= Time.deltaTime;
        }
        if(hp <= 0)
        {
            player.feedBlood(blood);
            gameObject.SetActive(false);
        }
    }
}
