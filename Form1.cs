//SARITA TIGADI
//1001634958
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ServerApplication
{
    public partial class Form1 : Form
    {
        static Int32 port = 10;
        static IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        static TcpListener tcpListener = new TcpListener(localAddr, port);
        static Dictionary<string, TcpClient> clientDict = new Dictionary<string, TcpClient>();
        static List<TcpClient> clientList = new List<TcpClient>();
        static int counter = 0;
        public static string Message;
        public static string ClientStatus;       
        static TcpClient socketForClient;
        public static int clientCount = 10;
        public static string clientName;

        public Form1()
        {
            InitializeComponent();
            StartServer();
        }
        /// <summary>
        ///Reference https://stackoverflow.com/questions/11181502/c-sharp-how-to-connect-multiple-clients-to-a-tcplistener
        ///Reference http://csharp.net-informations.com/communications/csharp-multi-threaded-server-socket.html
        ///Reference https://stackoverflow.com/questions/15878265/single-server-multiple-clients-in-c-sharp
        ///
        ///The StartServer() function initializes each of the thread with the Listener function and starts the thread.
        ///Creates an instance of TcpClient for each client that connects.
        ///Also starts the TcpListener which is already initilized for the local host and port 10 
        /// </summary>
        private void StartServer()
        {
            labelServerState.Text = "Server Started";           
            tcpListener.Start();
            socketForClient = new TcpClient();
            int numberOfClientsYouNeedToConnect = clientCount;
            for (int i = 0; i < numberOfClientsYouNeedToConnect; i++)
            {
                Thread newThread = new Thread(new ThreadStart(Listeners));
                newThread.Start();
            }
        }

        /// <summary>
        ///The Listeners() function accepts the connection request from the client.
        ///Initializes the networkStream to that specific client.
        ///It provides the client Registration and adds each client to the dictionary clientDict.
        ///It reads the inputadata from client and based on the option selected transmits data to either that specific client or all the clients.
        /// </summary>
        private void Listeners()
        {
            /// Reference https://stackoverflow.com/questions/11181502/c-sharp-how-to-connect-multiple-clients-to-a-tcplistener

            socketForClient = tcpListener.AcceptTcpClient();
            NetworkStream networkStream = socketForClient.GetStream();
            if (socketForClient.Connected)
            {
                counter++;
                byte[] clientMessage = new byte[1024];
                string clientData;
                int numberOfBytesRead = 0;               
                do
                {
                    numberOfBytesRead = networkStream.Read(clientMessage, 0, clientMessage.Length);
                    clientData = Encoding.ASCII.GetString(clientMessage, 0, numberOfBytesRead);
                }
                while (networkStream.DataAvailable);
              
                textBoxHTTPData.Text = clientData.ToString();
                string[] clientDataArray = clientData.Split('\n');
                JObject json = JObject.Parse(clientDataArray[5]);   
                
                if (json.Count == 1)
                {
                    ///Reference:  https://stackoverflow.com/questions/12402085/how-to-parse-json-object-in-c
                    ///Reference: https://social.msdn.microsoft.com/Forums/en-US/c0edfcc8-f889-4e04-bf88-6a0b81e8eae8/parsing-json-object?forum=csharpgeneral
                    
                    clientName = json["ClientName"].ToString();
                    listBoxClients.Items.Add(clientName.ToString() + "     Connected");   
                    clientDict.Add(clientName, socketForClient);                   
                }
                else if (json.Count > 1)
                {
                    Message = json["textMessage"].ToString();
                    if (Message != "Disconnect")
                    {
                        string option = json["option"].ToString();
                        string destClient = json["destinationClient"].ToString();
                        listBoxClientData.Items.Add(Message.ToString());                      
                        if (option == "option1")
                        {
                            sendToClient(destClient);
                        }
                        else if (option == "option2")
                        {
                            sendToAllClients();
                        }
                    }
                    else if (Message == "Disconnect")
                    {
                        listBoxClients.Items.Add(clientName.ToString() + "     Disconnected");
                    }              
                                      
                }              
            }
            else
            {
                listBoxClients.Items.Add(Message.ToString() + "     DisConnected");              
            }                     
        }

        /// <summary>
        ///The sendToClient(client) sends data to a specific client which is passed as a parameter
        /// </summary>
        static void sendToClient(string client)
        {
            if (clientDict.ContainsKey(client))
            {
                TcpClient socketForClient = clientDict[client];               
                NetworkStream networkStream = socketForClient.GetStream();
                /// Reference https://developer.mozilla.org/en-US/docs/Web/HTTP/Messages
                
                string sendResponse = Message.ToString();
                HttpResponseMessage.HttpBody = sendResponse;
                HttpResponseMessage.HttpContentLength = "Content - Length:" + sendResponse.Length.ToString() + "\r\n";
                byte[] responseStream = System.Text.Encoding.ASCII.GetBytes(HttpResponseMessage.HttpHost 
                  + HttpResponseMessage.HttpContentType + HttpResponseMessage.HttpContentLength + HttpResponseMessage.HttpBody);               
                networkStream.Write(responseStream, 0, responseStream.Length);
                networkStream.Flush();             
            }
        }

        /// <summary>
        ///The sendToAllClients() sends data to all the clients that have been registered to the server.
        /// </summary>
        void sendToAllClients()
        {         
            foreach (KeyValuePair<string, TcpClient> entry in clientDict)
            {
                sendToClient(entry.Key);
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);
            }                
        }

        /// <summary>
        ///The buttonStopServer_Click() method is to stop the server process.
        /// </summary>
        private void buttonStopServer_Click(object sender, EventArgs e)
        {
            if (socketForClient!=null)
            {
                if (socketForClient.Connected)
                {
                    socketForClient.Close();
                }                
            }
           
            foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
            {
                if (myProc.ProcessName == "ServerApplication")
                {
                    myProc.Kill();
                }
            }
            labelServerState.Text = "Server Stopped";
        }

        /// <summary>
        ///The buttonExit_Click() method is to close the server window.
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
            {
                if (myProc.ProcessName == "ServerApplication")
                {
                    myProc.Kill();
                }
            }
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
            {
                if (myProc.ProcessName == "ServerApplication")
                {
                    myProc.Kill();
                }
            }
        }
    }

    /// <summary>
    ///The HttpResponseMessage class has the HTTP fields and formats defined that will be used by the server while sending data.
    /// </summary>
    /// 
    public static class HttpResponseMessage
    {
        public static string HttpHost = "HTTP/1.1 200 OK\r\n";       
        public static string HttpContentType = "Content-Type: text/json\r\n";
        public static string HttpContentLength = "";       
        public static string HttpBody = "";
        public static string HttpDate = "Date: {Date}\r\n";
    }
}
