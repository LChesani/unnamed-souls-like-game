using TMPro;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    
    Slot[] slots;
    Vector2Int size;
    public Slot selected;
    public Item weaponSelected;

    Item cpy;
    void Start()
    {
        size = new Vector2Int(0, 16);
        slots = transform.GetChild(2).gameObject.GetComponentsInChildren<Slot>();
        this.gameObject.SetActive(false);
    }



    public void add(Item item)
    {

        if(size.x < size.y)
        {
            size.x += 1;
            for(int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item == null)
                {
                    slots[i].item = item;
                    item.transform.position = new Vector3(0.0f, -100.0f, 0.0f);
                    return;
                }
            }
        }
        return;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(selected.item != null)
            {
                transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = selected.item.name;
                weaponSelected = selected.item;
            }
        }
        
    }
}