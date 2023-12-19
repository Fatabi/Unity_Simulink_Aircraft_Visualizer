using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Free : MonoBehaviour
{
    public GameObject cameraFree;
    public float movementSpeed = 0.1f;
    private float tempMovementSpeed = 0.1f;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initEulerAngles;
    private float roll;
    private float yaw;
    private float pitch;
    public Text statusText;
    void Start()
    {
        initialPosition = cameraFree.transform.localPosition;
        initialRotation = cameraFree.transform.localRotation;
        initEulerAngles = cameraFree.transform.eulerAngles;
        roll = initEulerAngles.x;
        yaw = initEulerAngles.y;
        pitch = initEulerAngles.z;
    }
    void Update()
    {
        if (cameraFree.activeSelf)
        {            
            if (Input.GetKey(KeyCode.W))
            {
                cameraFree.transform.Translate(new Vector3(0,0,movementSpeed));
            }
            if (Input.GetKey(KeyCode.A))
            {
                cameraFree.transform.Translate(new Vector3(movementSpeed*(-1f),0,0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                cameraFree.transform.Translate(new Vector3(0,0,movementSpeed*(-1f)));
            }
            if (Input.GetKey(KeyCode.D))
            {
                cameraFree.transform.Translate(new Vector3(movementSpeed,0,0));
            }
            if (Input.GetKey(KeyCode.Space))
            {
                cameraFree.transform.Translate(new Vector3(0,movementSpeed,0));
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                cameraFree.transform.Translate(new Vector3(0,movementSpeed*(-1f),0));
            }
            if (Input.GetKey(KeyCode.R))
            {
                Reset_Position_and_Rotation();
            }

            if (Input.GetMouseButton(1))
            {
                yaw +=  Input.GetAxis("Mouse X")*4;
                roll += Input.GetAxis("Mouse Y")*4;
                    
                cameraFree.transform.eulerAngles = new Vector3(roll*(-1f),yaw,pitch);
            }
                
            tempMovementSpeed = movementSpeed;
            movementSpeed += Input.mouseScrollDelta.y*(0.05f)*movementSpeed;
            
            if (movementSpeed<0.01f)
            {
                movementSpeed = 0.01f;
            }
            if (tempMovementSpeed != movementSpeed)
            {
                statusText.text = "Camera Movement Speed:" + movementSpeed.ToString("F2");
            }
        }
        
    }
    void Reset_Position_and_Rotation()
    {
        cameraFree.transform.localPosition = initialPosition;
        cameraFree.transform.localRotation = initialRotation;
        roll = initEulerAngles.x;
        yaw = initEulerAngles.y;
        pitch = initEulerAngles.z;
        movementSpeed = 0.1f;
        statusText.text = "Camera Movement Speed:" + movementSpeed.ToString("F2");
    }
    void Change_Movement_Speed()
    {
        
    }
}
