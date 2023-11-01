using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] MainCharacter player;
    public GameObject goEnemies;
    public Enemy[] enemies;
    [SerializeField] GameObject[] essentials;
    public string activeBoss;
    void Start()
    {
        
        player.OnReset += resetCall;
        GameObject.DontDestroyOnLoad(this);
        foreach(GameObject Obj in essentials)
        {
            GameObject.DontDestroyOnLoad(Obj);
        }

        SceneManager.LoadScene("Map");
        
    }

    public void resetCall()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.parent.gameObject.SetActive(true);
            enemies[i].resetHp();
            enemies[i].transform.position = enemies[i].initialPos;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(goEnemies != null)
        {
            if (player.getHP().x <= 0.0f)
            {
                player.resetChk(true);
                resetCall();
            }
        }
    }
}
