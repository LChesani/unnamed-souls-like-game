using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class BossManager : MonoBehaviour
{
    Enemy[] bosses;
    public Enemy active;
    void Start()
    {
        bosses = GetComponentsInChildren<Enemy>();
    }

    void UiRender()
    {

    }

    void Update()
    {
        if(active != null)
        {
            UiRender();
        }
        
    }
}
