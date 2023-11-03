using UniGLTF;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject hand;
    [SerializeField] InventoryManager inventory;
    [SerializeField] MainCharacter mc;

    [SerializeField] TMPro.TextMeshProUGUI desc;

    [SerializeField] TMPro.TextMeshProUGUI req1;
    [SerializeField] TMPro.TextMeshProUGUI req2;

    [SerializeField] TMPro.TextMeshProUGUI sc1;
    [SerializeField] TMPro.TextMeshProUGUI sc2;

    [SerializeField] TMPro.TextMeshProUGUI dmg;
    Item selected;
    TMPro.TextMeshProUGUI gui;
    Button btn;
    void Start()
    {
        gui = GetComponent<TMPro.TextMeshProUGUI>();
        btn = transform.parent.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(use);
        selected = inventory.weaponSelected; 
    }

    Item aux = null;

    void use()
    {
        if(selected != null)
        {   if(mc.Using != null)
            {
                Destroy(mc.Using.gameObject);
                mc.Using = null;
            }

            aux = Instantiate(selected, hand.transform.position, Quaternion.identity);
            aux.transform.SetParent(hand.transform);
            aux.transform.localPosition = new Vector3(0.00013f, 0.00103f, -0.00038f);
            mc.Using = aux;
            mc.Using.picked = true;
        }
    }



    void Update()
    {
        selected = inventory.weaponSelected;
        if(selected != null)
        {
            desc.text = selected.Description;
            req1.text = selected.req.x.ToString();
            req2.text = selected.req.y.ToString();
            sc1.text = selected.damageScale.x.ToString();
            sc2.text = selected.damageScale.y.ToString();
            dmg.text = selected.damage.ToString();
        }
    }
}
