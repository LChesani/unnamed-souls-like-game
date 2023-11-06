using System.Collections;
using System.Collections.Generic;
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
    public float dmgDelay = 0.0f;
    Vector3 playerDirection;
    private void OnTriggerEnter(Collider collision)
    {
        if((dmgDelay <= 0.0f) && (collision.gameObject.tag == "Weapon") && player.attacking)
        {
            dmgDelay = 1.0f;
            hp -= player.calculateDamage();
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
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            playerDirection = player.transform.position - transform.position;
            playerDirection.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(playerDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

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
