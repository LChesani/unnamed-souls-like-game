using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLightSimulator : MonoBehaviour
{

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.deltaTime*10.0f), transform.position.z);
    }
}
