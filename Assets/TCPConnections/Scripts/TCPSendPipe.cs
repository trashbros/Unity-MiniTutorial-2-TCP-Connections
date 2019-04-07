using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;

namespace UnityTutorial
{
    public class TCPSendPipe : MonoBehaviour
    {
        public String Host = "localhost";
        public Int32 Port = 55000;

        TcpClient mySocket = null;
        NetworkStream theStream = null;
        StreamWriter theWriter = null;

        // Start is called before the first frame update
        void Start()
        {
            mySocket = new TcpClient();

            if (SetupSocket())
            {
                Debug.Log("socket is set up");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!mySocket.Connected)
            {
                SetupSocket();
            }
        }

        public bool SetupSocket()
        {
            try
            {
                mySocket.Connect(Host, Port);
                theStream = mySocket.GetStream();
                theWriter = new StreamWriter(theStream);
                Byte[] sendBytes = System.Text.Encoding.UTF8.GetBytes("yah!! it works");
                mySocket.GetStream().Write(sendBytes, 0, sendBytes.Length);
                Debug.Log("socket is sent");
                return true;
            }
            catch (Exception e)
            {
                Debug.Log("Socket error: " + e);
                return false;
            }
        }

        private void OnApplicationQuit()
        {
            if (mySocket != null && mySocket.Connected)
                mySocket.Close();
        }
    }
}