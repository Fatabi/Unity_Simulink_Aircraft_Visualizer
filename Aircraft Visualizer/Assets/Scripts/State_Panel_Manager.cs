using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class State_Panel_Manager : MonoBehaviour
{
    public GameObject[] panelValues;
    public Communication_Data comData;
    private List<Text> panelTexts = new List<Text>();
    
    void Start()
    {
        
        for (int i = 0; i < panelValues.Length; i++)
        {
            panelTexts.Add(panelValues[i].GetComponentInChildren<Text>());
        }
    }
    void Update()
    {
        int i = 0;
        panelTexts[i].text =  comData.x.ToString("F2")         ;i++;
        panelTexts[i].text =  comData.y.ToString("F2")         ;i++;
        panelTexts[i].text =  comData.z.ToString("F2")         ;i++;
        panelTexts[i].text =  comData.phi_deg.ToString("F2")     ;i++;
        panelTexts[i].text =  comData.theta_deg.ToString("F2")   ;i++;
        panelTexts[i].text =  comData.psi_deg.ToString("F2")     ;i++;
        panelTexts[i].text =  comData.p_deg_s.ToString("F2")     ;i++;
        panelTexts[i].text =  comData.q_deg_s.ToString("F2")     ;i++;
        panelTexts[i].text =  comData.r_deg_s.ToString("F2")     ;i++;
        panelTexts[i].text =  comData.rudder_deg.ToString("F2")  ;i++;
        panelTexts[i].text =  comData.flaperonRight_deg.ToString("F2") ;i++;
        panelTexts[i].text =  comData.elevatorRight_deg.ToString("F2");i++;
        panelTexts[i].text =  comData.thrust_per.ToString("F2")  ;i++;
        panelTexts[i].text =  comData.alpha_deg.ToString("F2")   ;i++;
        panelTexts[i].text =  comData.beta_deg.ToString("F2")    ;i++;
        panelTexts[i].text =  comData.flightPath_deg.ToString("F2")   ;i++;
        panelTexts[i].text =  comData.TAS_m_s.ToString("F2")     ;i++;
        panelTexts[i].text =  comData.Mach.ToString("F2")        ;i++;
        panelTexts[i].text =  comData.G.ToString("F2")           ;i++;
        panelTexts[i].text =  comData.Vz.ToString("F2")          ;i++;

    }
}
