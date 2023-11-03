using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] string action;
    [SerializeField] Animator animator;
    private void Start()
    {
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool(action, true);
        }
    }

    [SerializeField] BossManager bm;

    private void OnTriggerExit(Collider collision)
    {
        animator.SetBool(action, false);
    }
}