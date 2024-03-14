using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseyLook : MonoBehaviour
{

    private Vector3 Lookie;

    public float MouseSpeed;

    public float LookMax;

    public float LookMin;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        // looking left and right
        Lookie.y += Input.GetAxis("Mouse X") * MouseSpeed;
        // looking up and down (positive y axis in screen space is actually down, so make it opposite)
        Lookie.x += -Input.GetAxis("Mouse Y") * MouseSpeed;

        Lookie.x = Mathf.Clamp(Lookie.x, LookMin, LookMax);

        //this is actually making it look
        transform.eulerAngles = Lookie;
        
    }
}
