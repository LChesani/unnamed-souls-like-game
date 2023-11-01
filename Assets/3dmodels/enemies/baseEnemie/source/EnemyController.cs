using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] string action;
    [SerializeField] Animator animator;
    public MainCharacter player;

    float rotationSpeed;
    Vector3 playerDirection;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<MainCharacter>();
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

    private void OnTriggerExit(Collider collision)
    {
        animator.SetBool(action, false);
    }
}