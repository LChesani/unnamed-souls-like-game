using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopUp : MonoBehaviour
{
    [SerializeField] string toDo;
    [SerializeField] TMP_Text txt;
    [SerializeField] GameObject cnv;
   
    void Start()
    {
        txt.text = toDo;
        cnv.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cnv.SetActive(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cnv.SetActive(false);
        }
    }
}
