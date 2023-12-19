using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Deflect_Control_Surfaces : MonoBehaviour
{
    public Communication_Data comData;
    public Transform rudderBone; 
    public Transform elevatorRightBone;
    public Transform elevatorLeftBone;
    public Transform flaperonRightBone;
    public Transform flaperonLeftBone;

    private Quaternion initialRudderRotation;
    private Quaternion initialElevatorRightRotation;
    private Quaternion initialElevatorLeftRotation;
    private Quaternion initialFlaperonRightRotation;
    private Quaternion initialFlaperonLeftRotation;

    private Vector3 deflectAngle;
    void Start()
    {
        initialRudderRotation = rudderBone.localRotation; 
        initialElevatorRightRotation = elevatorRightBone.localRotation; 
        initialElevatorLeftRotation = elevatorLeftBone.localRotation; 
        initialFlaperonRightRotation = flaperonRightBone.localRotation; 
        initialFlaperonLeftRotation = flaperonLeftBone.localRotation; 
    }
    void Update()
    {
        rudderBone.localRotation        =   initialRudderRotation * Quaternion.Euler(0f, comData.rudder_deg*(-1f),0f);
        elevatorRightBone.localRotation =   initialElevatorRightRotation * Quaternion.Euler(0f, comData.elevatorRight_deg*(-1f),0f);
        elevatorLeftBone.localRotation  =   initialElevatorLeftRotation* Quaternion.Euler(0f, comData.elevatorLeft_deg,0f);
        flaperonRightBone.localRotation =   initialFlaperonRightRotation* Quaternion.Euler(0f, comData.flaperonRight_deg*(-1f),0f);
        flaperonLeftBone.localRotation  =   initialFlaperonLeftRotation* Quaternion.Euler(0f, comData.flaperonLeft_deg,0f);

     
    }
}
