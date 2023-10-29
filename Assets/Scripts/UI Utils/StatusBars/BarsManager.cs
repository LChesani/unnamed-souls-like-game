using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarsManager : MonoBehaviour
{
    [SerializeField] MainCharacter player;
    [SerializeField] GameObject currentHPBar;
    [SerializeField] GameObject maxHpBar;
    [SerializeField] GameObject currentStaminaBar;
    [SerializeField] GameObject maxStaminaBar;
    [SerializeField] GameObject bloodCount;
    TMPro.TextMeshProUGUI gui;
    Slider curHP;
    Slider maxHp;
    Slider curStamina;
    Slider maxStamina;
    Vector2 HP;
    Vector2 Stamina;
    void Start()
    {
        gui = bloodCount.GetComponent<TMPro.TextMeshProUGUI>();
        HP = player.getHP();
        Stamina = player.getStamina();
        curHP = currentHPBar.GetComponent<Slider>();
        maxHp = maxHpBar.GetComponent<Slider>();
        curStamina = currentStaminaBar.GetComponent<Slider>();
        maxStamina = maxStaminaBar.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        HP = player.getHP();
        gui.text = player.getBlood().ToString();
        curHP = currentHPBar.GetComponent<Slider>();
        maxHp = maxHpBar.GetComponent<Slider>();
        curHP.value = HP.x;
        maxHp.value = HP.y;

        Stamina = player.getStamina();
        curStamina = currentStaminaBar.GetComponent<Slider>();
        maxStamina = maxStaminaBar.GetComponent<Slider>();
        curStamina.value = Stamina.x;
        maxStamina.value = Stamina.y;
    }
}