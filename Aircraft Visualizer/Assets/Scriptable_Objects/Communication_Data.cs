using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[CreateAssetMenu(fileName = "Create simulink communication object",menuName ="Communication Data")]
public class Communication_Data : ScriptableObject
{
public string ip                ;
public int port              ;
public float x                 ;
public float y                 ;
public float z                 ;
public float phi_deg               ;
public float theta_deg             ;
public float psi_deg               ;
public float rudder_deg        ;
public float flaperonRight_deg ;
public float flaperonLeft_deg  ;
public float elevatorRight_deg ;
public float elevatorLeft_deg  ;
public float thrust_per       ; 
public float cgX_m            ;
public float cgY_m              ;
public float cgZ_m              ;
public float alpha_deg         ;
public float beta_deg          ;
public float flightPath_deg   ;
public float TAS_m_s        ;
 public float Mach        ;   
 public float G           ;   
 public float Vz          ;   
 public float p_deg_s     ;   
 public float q_deg_s     ;   
 public float r_deg_s     ;   
public float reset;
}
