using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    Enemy[] bosses;

    public GameObject active;
    [SerializeField] TMPro.TextMeshProUGUI nameBox;
    [SerializeField] Slider hp;
    Enemy activeEnemy;
    MainCharacter player;
    void Start()
    {
        bosses = GetComponentsInChildren<Enemy>();
        foreach(Enemy boss in bosses)
        {
            boss.gameObject.SetActive(false);
        }
    }

    void UiRender()
    {
        hp.value = activeEnemy.hp;
    }
    string bossName;
    public void activate()
    {
        player = GameObject.FindWithTag("Player").GetComponent<MainCharacter>();
        active = transform.Find(bossName).gameObject;
        active.SetActive(true);   
        activeEnemy = active.GetComponent<Enemy>();
        activeEnemy.player = player;
        hp.maxValue = activeEnemy.maxHp;
        nameBox.text = activeEnemy.bossName;
    }
    GameManager gm;

    void end() //trata o final da batalha
    {

    }

    void Update()
    {   if(GameObject.FindWithTag("GameManager") != null)
        {
            gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            bossName = gm.activeBoss;
            activate();
        }
        if(activeEnemy != null)
        {
            UiRender();
            if(activeEnemy.hp < 0.0f)
            {
                end();
            }
        }
    }
}
