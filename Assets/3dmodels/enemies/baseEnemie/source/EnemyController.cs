using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] string action;
    [SerializeField] Animator animator;
    [SerializeField] MainCharacter player;

    float rotationSpeed;
    Vector3 playerDirection;
    bool close;
    Enemy thisEnemy;
    private void Start()
    {
        thisEnemy = transform.parent.transform.GetComponent<Enemy>();
        rotationSpeed = 2.0f;
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerDirection = player.transform.position - transform.parent.transform.position;
            playerDirection.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(playerDirection);
            transform.parent.transform.rotation = Quaternion.Slerp(transform.parent.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            animator.SetBool(action, true);
        }
    }

    [SerializeField] BossManager bm;
     
    private void OnTriggerEnter(Collider collision)
    {
        if(thisEnemy.bossName.Length > 0)
        {
            thisEnemy.transform.parent.transform.GetComponent<BossManager>().active = thisEnemy;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        animator.SetBool(action, false);
    }
}