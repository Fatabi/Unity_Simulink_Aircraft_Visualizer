using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aircraft_Position_and_Rotation : MonoBehaviour
{
    public GameObject aircraft;
    public Transform noseAxes;
    public Communication_Data comData;
    private Vector3 simulinkToUnityPosition_m;
    private Vector3 rotTransform;
    private Quaternion simulinkToUnityRotation_quat;
    
    void Start()
    {
       Update_Aircraft_Pos_and_Rot();
       this.GetComponent<Effect_Manager>().Reset_Trails();        
    }
    void Update()
    {
        Update_Aircraft_Pos_and_Rot();
    }
    void Update_Aircraft_Pos_and_Rot()
    {
        simulinkToUnityPosition_m = new Vector3 (comData.y,comData.z*(-1f),comData.x);
        // rotTransform = new Vector3(comData.phi_deg*(-1f),comData.psi_deg,comData.theta_deg);
        rotTransform = new Vector3(comData.theta_deg*(-1f),comData.psi_deg,comData.phi_deg*(-1f));
        simulinkToUnityRotation_quat = Quaternion.Euler(rotTransform);
        aircraft.transform.SetPositionAndRotation(simulinkToUnityPosition_m,simulinkToUnityRotation_quat);

        noseAxes.localPosition = new Vector3(comData.cgY_m*(-1f),comData.cgZ_m,comData.cgX_m*(-1f));
    }
}
