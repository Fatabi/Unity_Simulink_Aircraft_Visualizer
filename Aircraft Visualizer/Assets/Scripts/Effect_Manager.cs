using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Manager : MonoBehaviour
{
    public GameObject trails;
    public Communication_Data comData;
    private float tempReset;
    private Vector3 temPos;
    private Vector3 curPos;
    void Start(){
        tempReset = comData.reset;
        temPos = new Vector3(comData.x,comData.y,comData.z);
        Reset_Trails();
    }
    void Update()
    {
        curPos = new Vector3(comData.x,comData.y,comData.z);
        float travelDistance = Vector3.Distance(curPos,temPos);
        if ((comData.reset != tempReset)||(travelDistance > 100f))
        {
            Reset_Trails();
        }
        tempReset = comData.reset;
        temPos = new Vector3(comData.x,comData.y,comData.z);
    }

    public void Reset_Trails(){
        trails.GetComponent<TrailRenderer>().Clear();
    }
    public void Hide_Show_Trails(){
        if (trails.activeSelf)
        {
            trails.SetActive(false);    
        }
        else
        {
            trails.SetActive(true);    
        }
        
    }
}
