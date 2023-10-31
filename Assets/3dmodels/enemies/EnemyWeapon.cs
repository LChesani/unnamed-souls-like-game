using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] public float damageDelay;
    public float damage;

    public float getDamage()
    {
        return damage;
    }
}