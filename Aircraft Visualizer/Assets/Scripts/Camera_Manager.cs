using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Manager : MonoBehaviour
{
    public GameObject[] cameras;
    public Text statusText;
    private int selected_camera = 1;
    
    void Update()
    {
        int temp_selected_camera = selected_camera;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selected_camera = 1;
            statusText.text = "Push down right click to change the view. Scroll for zoom. R for reset.";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selected_camera = 2;
            statusText.text = "Fixed Camera";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selected_camera = 3;
            statusText.text = "Fixed Camera";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selected_camera = 4;
            statusText.text = "Fixed Camera";
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selected_camera = 5;
            statusText.text = "Fixed Camera";
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selected_camera = 6;
            statusText.text = "Free Camera: W,A,S,D,Space,CTRL and right click. Scroll for speed. R for reset.";
        }
        // for (int i = 0; i < cameras.Length; i++)
        // {
        // if (Input.GetKeyDown((KeyCode)(48+i)))
        // {
        //     selected_camera = i;
        // }
        // }
        
        if (temp_selected_camera != selected_camera)
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                if ((i == (selected_camera-1)))
                {
                    cameras[i].SetActive(true);
                }
                else
                {
                    cameras[i].SetActive(false);
                }
            }
        }
    }
}
