using System.Collections;
using System.Collections.Generic;
using UniGLTF;
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
    GameObject sanctuary;
    GameObject sanctuaryCollider;
    [SerializeField] Type t;
    [SerializeField] public Vector2Int req; //requirements
    [SerializeField] public Vector2 damageScale;
    public bool picked = false;


    private void Start()
    {
        sanctuary = transform.GetChildByName("Sanctuary").gameObject;
        sanctuaryCollider = transform.GetChildByName("SanctuaryCollider").gameObject;
    }
    public void pick()
    {
        picked = true;
        sanctuary.SetActive(false);
        sanctuaryCollider.SetActive(false);
    }

    void Update()
    {
        if (!picked)
        {
            transform.Rotate(0.0f, Time.deltaTime * 25.0f, 0.0f);
            sanctuary.transform.Rotate(0.0f, -Time.deltaTime * 25.0f, 0.0f);
        }
    }
}