using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Boss1 : MonoBehaviour
{
    [SerializeField] GameObject root;
    [SerializeField] GameObject weapon;
    [SerializeField] Animator animator;
    [SerializeField] Enemy self;
    [SerializeField] float damage;
    System.Random rnd = new System.Random();
    string[] actions =
    {
        "attack1",
        "attack2",
        "attack3"
    };

    void Start()
    {
        weapon.transform.localPosition = new Vector3(0.00029f, 0.00243f, -0.0004f);
    }

    string choseAction()
    {
        return actions[rnd.Next(actions.Length)];
    }
    bool close;
    bool walking;
    void Update()
    {
        close = Vector3.Distance(transform.position, self.player.transform.position) < 10.0f;
        walking = animator.GetCurrentAnimatorStateInfo(0).IsName("Walk");
        if (close && walking)
        {
            animator.SetTrigger(choseAction());
        }
        self.damage = Convert.ToInt32(!walking) * damage;
        weapon.transform.localRotation = root.transform.localRotation * Quaternion.Euler(77.4f, 90.0f, 0.0f);
    }
}
