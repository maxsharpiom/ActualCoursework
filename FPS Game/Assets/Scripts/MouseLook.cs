using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        //Locks the cursor to the centre of the screen as well as hides it
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        ///Set mouseX equal to the input from mouse x
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        ///Set mouseY equal to the input from mouse y
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        ///Every frame the x rotation is decreased based on mouse y
        xRotation -= mouseY;
        ///Limit the degree of rotation to between -90 and 90 degrees (stops the player from looking behind them)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        ///Rotate about the y axis (Vector3.up), the amount specified by mouseX
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
