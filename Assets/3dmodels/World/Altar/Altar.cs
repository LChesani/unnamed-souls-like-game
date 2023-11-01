using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Altar : MonoBehaviour
{
    public MainCharacter player;
    [SerializeField] GameObject altarCanvas;
    [SerializeField] GameObject lvlObj;
    [SerializeField] GameObject exitObj;
    [SerializeField] GameObject lvlCanvas;
    private Button levelUp;
    private Button leave;
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                player.chk = this;
                player.resetChk(false);
                player.inAltar = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                altarCanvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Leave();
    }


    private void Leave()
    {
        player.inAltar = false;
        altarCanvas.SetActive(false);
        lvlCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void levelIncrease()
    {
        altarCanvas.SetActive(false);
        lvlCanvas.SetActive(true);
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<MainCharacter>();
        levelUp = lvlObj.transform.gameObject.GetComponent<Button>();
        levelUp.onClick.AddListener(levelIncrease);
        leave = exitObj.transform.gameObject.GetComponent<Button>();
        leave.onClick.AddListener(Leave);
        altarCanvas.SetActive(false);
        lvlCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
