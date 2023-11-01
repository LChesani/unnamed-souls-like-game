using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] Vector2 HP; //Hp and max HP
    [SerializeField] Vector2 Stamina; //Stamina and Max Stamina
    [SerializeField] InventoryManager inventory;
    [SerializeField] GameObject aura;
    [SerializeField] GameObject hand;
    private int bloodOfFools;
    private bool isShowing;
    Dictionary<string, Attribute> attributes;
    public bool dashing;
    private int Level;
    private bool staminaRunOut;
    public bool attacking;
    private float attackCoolDown;
    public bool isRunning;
    public Item Using;
    public bool inAltar;
    public bool healing;
    public Altar chk;

    public Vector2 getHP() { return HP; }
    public Vector2 getStamina() {return Stamina; }


    public bool pick = false;
    public void adjustStamina(float val)
    {
        Stamina.x += val;
        Stamina.x = Mathf.Clamp(Stamina.x, 0.0f, Stamina.y);
    }

    public void feedBlood(int v) { bloodOfFools += v; }

    public int getBlood() { return bloodOfFools;}

    public int getCost()
    {
        float lvl = getLevel();
        return (int)(0.5f * (lvl * lvl * lvl) + 1.0f * (lvl * lvl) + 2.0f * (lvl));
    }

    public void takeDamage(float v)
    {
        HP.x -= v;
    }

    private void recalc()
    {
        HP.y = 500.0f + (attributes["Vitality"].getValue() - 1.0f) * 750.0f / 49.0f;
        Stamina.y = 250.0f + (attributes["Endurance"].getValue() - 1.0f) * 625.0f / 49.0f;
    }

    public void incLevel(int v) { 
        Level += v;
        recalc();
    }

    public int getLevel() { return Level; }

    public bool getStaminaRunOut() { return staminaRunOut; }
    
    public Attribute GetAttribute(string name)
    {
        return attributes[name];
    }
    private bool called = false;
    public void initAttribs()
    {   if (called) return;
        called = true;
        attributes = new Dictionary<string, Attribute>();
        attributes.Add("Vitality", new Attribute("Vitality", "Increases character's HP"));
        attributes.Add("Endurance", new Attribute("Endurance", "Icreasses character's stamina, stamina is used to attack, run and dodge"));
        attributes.Add("Strength", new Attribute("Strength", "Stronger characters carry heavier weapons, also increases damage of str based weapons"));
        attributes.Add("Dexterity", new Attribute("Dexterity", "Makes it possible to handle difficult weapons, , also increases damage of dex based weapons"));
    }

    public event Action OnReset;


    public void resetChk(bool byDeath)
    {
        HP.x = HP.y;
        Stamina.x = Stamina.y;
        if(byDeath)
        {
            isRunning = false;
            attacking = false;
            bloodOfFools /= 2;
            if(chk != null)
            {
                transform.position = chk.transform.position; //volta pro checkpoint
            }
            else
            {
                transform.position = Vector3.zero;
            }
            
        }
        OnReset?.Invoke();
    }

    public float calculateDamage() //(base + escala)/(2.5+e * ehIncapaz)
    {
        if(attributes == null)
        {
            return 0;
        }
        float dmg = (Using.damage + 5.0f * (attributes["Strength"].getValue() * Using.damageScale.x + attributes["Dexterity"].getValue() * Using.damageScale.y));
        if(Using.req.x > attributes["Strength"].getValue() || Using.req.y > attributes["Dexterity"].getValue()){
            dmg /= 2.5f;
        }
        return dmg;
    }

    Item chosen = null;
    float pickCount = 0.0f;
 
    private void OnTriggerStay(Collider collision)
    {   
        if(collision.gameObject.tag == "Sanctuary")
        {
            if (Input.GetKeyDown(KeyCode.F)){
                pick = true;
                pickCount = 2.0f;
                chosen = collision.gameObject.transform.parent.gameObject.GetComponent<Item>();
            }
        }
    }

    public float dmgDelay = 0.0f;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "EnemyWeapon")
        {
            if (!dashing && dmgDelay <= 0.0f)
            {
                dmgDelay = collision.gameObject.GetComponent<EnemyWeapon>().damageDelay;
                HP.x -= collision.gameObject.GetComponent<EnemyWeapon>().getDamage();
            }
        }
    }

    private void Start()
    {
        chk = null;
        inAltar = false;
        bloodOfFools = 999999;
        isRunning = false;
        isShowing = false;
        dashing = false;
        Using = null;
        attacking = false;
        Level = 1;
        HP = new Vector2(500.0f, 500.0f);
        Stamina = new Vector2(250.0f, 250.0f);
    }

    void heal()
    {
        
        if(HP.x < HP.y)
        {
            healing = true;
            HP.x += 50.0f * Time.deltaTime;
            bloodOfFools -= (int)(500.0f * Time.deltaTime);
        }
    }

    void Update()
    {

        if(Using != null)
        {
            Using.transform.localRotation = hand.transform.localRotation * Quaternion.Euler(-90.0f, 0.0f, 0.0f);
        }

        if(dmgDelay >= 0.0f)
        {
            dmgDelay -= Time.deltaTime;
        }

        aura.SetActive(healing);
        if(chosen != null)
        {
            if (pickCount >= 0)
            {
                pickCount -= Time.deltaTime;
            }
            else
            {
                chosen.pick();
                inventory.add(chosen);
                chosen = null;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isShowing = !isShowing;
            inventory.gameObject.SetActive(isShowing);
            Cursor.visible = isShowing;
            if (isShowing)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if(Input.GetKey(KeyCode.G) && HP.x < HP.y) {
            heal();
        }
        else
        {
            healing = false;
        }
        

        if (Input.GetKey(KeyCode.LeftShift) && !staminaRunOut)
        {
            if(!dashing) { this.Stamina.x -= 0.6f; }
            
            if(this.Stamina.x < 0.0f)
            {
                staminaRunOut = true;
                Stamina.x = 0.0f;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            staminaRunOut = false;
        }

        if(attackCoolDown >= 0.0f)
        {
            attackCoolDown  -= Time.deltaTime;
        }
        else
        {
            attacking = false;
        }

        if (Input.GetMouseButtonDown(0) && !attacking && Using != null && Stamina.x > Using.staminaCost)
        {
            attacking = true;
            Stamina.x -= Using.staminaCost;
            attackCoolDown = 0.6f;
        }

        else if (Stamina.x < Stamina.y && !dashing && !attacking)
        {
            Stamina.x += 0.4f;
        }
    }
    
}
