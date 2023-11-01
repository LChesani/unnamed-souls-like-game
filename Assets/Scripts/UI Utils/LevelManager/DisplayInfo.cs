using UnityEngine.UI;
using UnityEngine;

public class DisplayInfo : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI gui;
    public MainCharacter player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<MainCharacter>();
    }
    void Update()
    {
        int lvl = player.getLevel();
        gui.text = "Level : " + player.getLevel() + "\n" + "Cost : " + 2*player.getCost();
    }
}
