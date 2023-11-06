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

    System.Random rnd = new System.Random();
    string[] actions =
    {
        "attack1",
        "attack2",
        "attack3",
        "attack4"
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
    string chosen = "";
    void Update()
    {
        close = Math.Abs(Vector3.Distance(transform.position, self.player.transform.position)) < 4.0f;
        walking = animator.GetCurrentAnimatorStateInfo(0).IsName("Walk");
        
        if (close && walking)
        {
            if(chosen != "") animator.SetBool(chosen, false);
            chosen = choseAction();
            animator.SetBool(chosen, true);
        }
        
        weapon.transform.localRotation = root.transform.localRotation * Quaternion.Euler(77.4f, 90.0f, 0.0f);
    }
}
