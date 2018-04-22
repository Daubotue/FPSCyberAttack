﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class ClientHandleData : MonoBehaviour
{

    public static ClientHandleData instance;

    private void Awake()
    {
        instance = this;
    }



    //Test Switch Statment
    void HandleMessages(int packetNum, byte[] data)
    {
        switch (packetNum)
        {
            case 1:
                HandleReturnedMessage(packetNum, data);
                break;
            case 2:
                break;
        }
    }


    void HandleReturnedMessage(int packetNum, byte[] data)
    {
        //Send  the Message for the Sever back to the Unity Console 
        int packetnum;
        FLI.ByteBuffer buffer = new FLI.ByteBuffer();
        buffer.WriteBytes(data);
        packetnum = buffer.ReadInt();
        String mes = buffer.ReadString();
        //Send to Unity console for now
        Debug.Log(mes);
    }

    public void HandleData(byte[] data)
    {
        int packetnum;
        FLI.ByteBuffer buffer= new FLI.ByteBuffer();
        buffer.WriteBytes(data);
        packetnum = buffer.ReadInt();
        buffer = null;
        if (packetnum == 0)
            return;

        HandleMessages(packetnum, data);
    }

  
}