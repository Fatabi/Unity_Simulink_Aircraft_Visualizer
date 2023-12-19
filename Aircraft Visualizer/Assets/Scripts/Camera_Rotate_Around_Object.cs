using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera_Rotate_Around_Object : MonoBehaviour
{   public GameObject cameraParent;
    public GameObject cameraObject;
    private float yaw;
    private float pitch;
    private float roll;
    float zoom = 30f;
    private Vector3 initEulerAngles;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        initialPosition = cameraObject.transform.localPosition;
        initialRotation = cameraParent.transform.localRotation ;
        initEulerAngles = cameraParent.transform.eulerAngles;
        roll = initEulerAngles.x;
        yaw = initEulerAngles.y;
        pitch = initEulerAngles.z;
    }
    void Update()
    {
        if (cameraParent.activeSelf)
        { 
            if (Input.GetMouseButton(1))
            {
                yaw +=  Input.GetAxis("Mouse X");
                pitch += Input.GetAxis("Mouse Y");
                    
                cameraParent.transform.eulerAngles = new Vector3(roll,yaw,pitch);
            }
            if (Input.GetKey(KeyCode.R))
            {
                Reset_Position_and_Rotation();
            }
                cameraObject.transform.localPosition =  new Vector3(cameraObject.transform.localPosition.x+Input.mouseScrollDelta.y,0f,0f);        
                // zoom += Input.mouseScrollDelta.y;
                // cameraObject.localPosition = cameraObject.right * zoom;
        }
    }
    void Reset_Position_and_Rotation()
    {
        cameraObject.transform.localPosition = initialPosition;
        cameraParent.transform.localRotation = initialRotation;
        roll = initEulerAngles.x;
        yaw = initEulerAngles.y;
        pitch = initEulerAngles.z;
    }
}
