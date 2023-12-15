using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    Vector3 dir;
    public Vector3 target;
    void Start()
    {
        dir = (target - transform.position).normalized;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if((target - transform.position).magnitude > 50.0f)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(10.0f * Time.deltaTime * dir);
    }
}
