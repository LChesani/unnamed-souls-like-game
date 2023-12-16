using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] int cost;
    [SerializeField] GameObject portalParent;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            if (other.GetComponent<MainCharacter>().getBlood() >= cost) { }
            {
                other.GetComponent<MainCharacter>().feedBlood(-cost);
                portalParent.SetActive(false);
            }
        }
    }
}
