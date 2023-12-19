using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine.Networking;

public class UDP_Receive : MonoBehaviour
{
    public Communication_Data comData;
    private UdpClient _ReceiveClient;
    private Thread _ReceiveThread;
    private IPEndPoint ipEndPoint;
    
    
    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        ipEndPoint = new IPEndPoint(IPAddress.Parse(comData.ip), comData.port);
        _ReceiveThread = new Thread(
            new ThreadStart(ReceiveData));
        _ReceiveThread.IsBackground = true;
        _ReceiveThread.Start();
        
    }

    private void ReceiveData()
    {
        _ReceiveClient = new UdpClient(comData.port);
        
        while (true)
        {
            try
            {
                /*PEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);*/
                byte[] data = _ReceiveClient.Receive(ref ipEndPoint);
                if (data != null)
                {
                    Decode_Data(data);
                }
                
            }
            catch (Exception err)
            {
                // Debug.Log("<color=red>" + err.Message + "</color>");
            }
        }
    }
    private void OnApplicationQuit()
    {
        try
        {
            _ReceiveThread.Abort();
            _ReceiveThread = null;
            _ReceiveClient.Close();
        }
        catch (Exception err)
        {
            // Debug.Log("<color=red>" + err.Message + "</color>");
        }
    }
    private void Decode_Data(byte[] data)
    {
        //Array.Reverse(data);
            int idx = 0;
            comData.x                  = BitConverter.ToSingle(data, idx); idx += 4;
            comData.y                  = BitConverter.ToSingle(data, idx); idx += 4;
            comData.z                  = BitConverter.ToSingle(data, idx); idx += 4;
            comData.phi_deg            = BitConverter.ToSingle(data, idx); idx += 4;
            comData.theta_deg          = BitConverter.ToSingle(data, idx); idx += 4;
            comData.psi_deg            = BitConverter.ToSingle(data, idx); idx += 4;
            comData.rudder_deg         = BitConverter.ToSingle(data, idx); idx += 4;
            comData.flaperonRight_deg  = BitConverter.ToSingle(data, idx); idx += 4;
            comData.flaperonLeft_deg   = BitConverter.ToSingle(data, idx); idx += 4;
            comData.elevatorRight_deg  = BitConverter.ToSingle(data, idx); idx += 4;
            comData.elevatorLeft_deg   = BitConverter.ToSingle(data, idx); idx += 4;
            comData.thrust_per         = BitConverter.ToSingle(data, idx); idx += 4;
            comData.cgX_m              = BitConverter.ToSingle(data, idx); idx += 4;
            comData.cgY_m              = BitConverter.ToSingle(data, idx); idx += 4;
            comData.cgZ_m              = BitConverter.ToSingle(data, idx); idx += 4;
            comData.alpha_deg          = BitConverter.ToSingle(data, idx); idx += 4;
            comData.beta_deg           = BitConverter.ToSingle(data, idx); idx += 4;
            comData.flightPath_deg     = BitConverter.ToSingle(data, idx); idx += 4;
            comData.TAS_m_s            = BitConverter.ToSingle(data, idx); idx += 4;
            comData.Mach               = BitConverter.ToSingle(data, idx); idx += 4;
            comData.G                  = BitConverter.ToSingle(data, idx); idx += 4;
            comData.Vz                 = BitConverter.ToSingle(data, idx); idx += 4;
            comData.p_deg_s            = BitConverter.ToSingle(data, idx); idx += 4;
            comData.q_deg_s            = BitConverter.ToSingle(data, idx); idx += 4;
            comData.r_deg_s            = BitConverter.ToSingle(data, idx); idx += 4;
            comData.reset              = BitConverter.ToSingle(data, idx); idx += 4;
    }
}