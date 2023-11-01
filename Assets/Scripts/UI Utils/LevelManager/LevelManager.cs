using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public MainCharacter player;
    [SerializeField] GameObject lvlDisplay;
    [SerializeField] GameObject goBtnSub;
    [SerializeField] GameObject goBtnAdd;
    Attribute attribute;
    TMPro.TextMeshProUGUI gui;
    Button btn;
    private int n_levels;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<MainCharacter>();
        player.initAttribs();
        attribute = player.GetAttribute(name);
        goBtnAdd.GetComponent<Button>().onClick.AddListener(Inc);
        goBtnSub.GetComponent<Button>().onClick.AddListener(Dec);
        gui = transform.parent.transform.parent.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(getDesc);
    }

    void getDesc()
    {
        gui.text = attribute.Description;
    }

    void Inc()
    {
        if(canLevel() >= 2)
        {
            attribute.modifyValue(1);
            player.feedBlood(-player.getCost() * 2);
            player.incLevel(1);
        }
    }
    void Dec()
    {   if(canLevel() >= 1 && player.getLevel() > 1) {
            attribute.modifyValue(-1);
            player.feedBlood(-player.getCost());
            player.incLevel(-1);
        }     
    }

    public int canLevel()
    {
        return player.getBlood() / player.getCost();
    }

    void Update()
    {
        lvlDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = attribute.getValue().ToString();
    }
}
