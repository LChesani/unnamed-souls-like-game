using UnityEngine.UI;
using UnityEngine;

public class DisplayInfo : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI gui;
    [SerializeField] MainCharacter player;

    void Update()
    {
        int lvl = player.getLevel();
        gui.text = "Level : " + player.getLevel() + "\n" + "Cost : " + 2*player.getCost();
    }
}
