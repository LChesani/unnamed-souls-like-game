using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    [SerializeField] GameObject head;
    [SerializeField] GameObject mc;
    Vector2 mouse = Vector2.zero;
    float sensibility = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(mc.transform.position.x, mc.transform.position.y + 1.8f, mc.transform.position.z);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(mc.transform.position.x, mc.transform.position.y + 1.8f, mc.transform.position.z);
        mouse.x = Input.GetAxis("Mouse X");
        mouse.y = -Input.GetAxis("Mouse Y");
        
        transform.localRotation *= Quaternion.AngleAxis(mouse.x * sensibility, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(mouse.y * sensibility, Vector3.right);

        var angles = transform.localEulerAngles;
        angles.z = 0;

        var angle = angles.x;

        if(angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if(angle < 180 && angle > 40){
            angles.x = 40;
        }

        transform.localEulerAngles = angles;
    }
}
