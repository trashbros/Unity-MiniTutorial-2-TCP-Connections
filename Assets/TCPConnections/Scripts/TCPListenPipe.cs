using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace UnityTutorial
{
    public class TCPListenPipe : MonoBehaviour
    {
        public String Host = "localhost";
        public Int32 Port = 55000;

        private TcpListener listener = null;
        private TcpClient client = null;
        private NetworkStream ns = null;
        string msg;

        // Start is called before the first frame update
        void Awake()
        {
            listener = new TcpListener(Dns.GetHostEntry(Host).AddressList[1], Port);
            listener.Start();
            Debug.Log("is listening");

            if (listener.Pending())
            {
                client = listener.AcceptTcpClient();
                Debug.Log("Connected");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (client == null)
            {
                if (listener.Pending())
                {
                    client = listener.AcceptTcpClient();
                    Debug.Log("Connected");
                }
                else
                {
                    return;
                }
            }

            ns = client.GetStream();

            if ((ns != null) && (ns.DataAvailable))
            {
                StreamReader reader = new StreamReader(ns);
                msg = reader.ReadToEnd();
                Debug.Log(msg);
            }
        }

        private void OnApplicationQuit()
        {
            if (listener != null)
                listener.Stop();
        }
    }
}