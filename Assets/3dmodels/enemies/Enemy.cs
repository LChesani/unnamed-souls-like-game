using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] public float maxHp;
    [SerializeField] public float damage;
    public MainCharacter player;
    [SerializeField] EnemyWeapon weapon;
    [SerializeField] int blood;
    [SerializeField] public string bossName;
    [SerializeField] Animator animator;
    public Vector3 initialPos;
    public float hp;
    Vector3 playerDirection;
    private void OnTriggerEnter(Collider collision)
    {
        if((collision.gameObject.tag == "Weapon") && player.attacking)
        {
            hp -= player.calculateDamage();
            collision.gameObject.transform.parent.GetComponent<Item>().damage = 0;
        }
    }

    public void resetHp()
    {
        hp = maxHp;
    }

    private void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<MainCharacter>();
        hp = maxHp;
        initialPos = transform.position;
    }
    float rotationSpeed = 2.0f;
    [SerializeField] float attackTimer;
    public float timing = 0.0f;
    public void damageOn()
    {
        weapon.damage = damage;
        timing = attackTimer;
    }
    
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            playerDirection = player.transform.position - transform.position;
            playerDirection.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(playerDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        if(weapon != null)
        {
            if (timing > 0.0f)
            {
                timing -= Time.deltaTime;
                weapon.damage = damage;
            }
            else
            {
                weapon.damage = 0.0f;
            }
        }
        
        

        if(hp <= 0)
        {
            player.feedBlood(blood);
            gameObject.SetActive(false);
        }
    }
}
