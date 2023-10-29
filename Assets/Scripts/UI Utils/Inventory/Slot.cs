using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public Sprite icon;
    [SerializeField] Sprite defaultIcon;
    [SerializeField] InventoryManager inventoryManager;
    public Item item;
    Image render;

    void Start()
    {
        render = GetComponent<Image>();
    }

 
    void Update()
    {
        if(RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition))
        {
            inventoryManager.selected = this;
        }
        if (item == null)
        {
            render.sprite = defaultIcon;
        }
        else
        {
            render.sprite = item.icon;
        }
    }
}