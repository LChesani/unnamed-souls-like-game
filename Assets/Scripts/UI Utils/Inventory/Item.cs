using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Item : MonoBehaviour
{

    public enum Type
    {
        Weapon,
        Armor,
        Consumable
    }


    [SerializeField] public int id;
    [SerializeField] public string Name;
    [SerializeField] public Sprite icon;
    [SerializeField] public string Description;
    [SerializeField] public float damage;
    [SerializeField] public float blockDamage;
    [SerializeField] public float staminaCost;
    [SerializeField] GameObject sanctuary;
    [SerializeField] Type t;
    [SerializeField] public Vector2Int req; //requirements
    [SerializeField] public Vector2 damageScale;
    public bool picked = false;


    
    public void pick()
    {
        picked = true;
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    void Update()
    {
        if (!picked)
        {
            transform.Rotate(0, Time.deltaTime * 25.0f, Time.deltaTime * 25.0f);
            sanctuary.transform.localRotation = Quaternion.Inverse(transform.localRotation);
        }
    }
}