using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    Enemy[] bosses;
    public Enemy active;
    [SerializeField] TMPro.TextMeshProUGUI bossName;
    [SerializeField] Slider hp;
    void Start()
    {
        bosses = GetComponentsInChildren<Enemy>();
    }

    void UiRender()
    {
        hp.value = active.hp;
    }

    public void activate(Enemy enemy)
    {
        hp.maxValue = active.maxHp;
        this.active = enemy;
        bossName.text = active.bossName;
    }

    void Update()
    {   
        if(active != null)
        {
            UiRender();
        }
        
    }
}
