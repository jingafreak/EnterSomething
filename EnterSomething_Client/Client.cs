using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EnterSomething_Client
{
    public class Client
    {
        private static Socket _clientSocket;
        private static bool _clientConnected;
        private const int PORT = 3131;
        private const int BUFFER_SIZE = 2048;
        private static byte[] buffer = new byte[BUFFER_SIZE];
        private static String _username;

        private static GUI _gui;

        public static void Connect(GUI gui)
        {
            Client._gui = gui;
            Client._username = _gui.tbClientUsername.Text;
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            while (!_clientSocket.Connected)
            {
                try
                {
                    if (_gui.tbClientIP.Text.ToLower().Trim() == "loopback" || _gui.tbClientIP.Text.ToLower().Trim() == "lb")
                    {
                        _clientSocket.Connect(IPAddress.Loopback, PORT);
                    }
                    else
                    {
                        _clientSocket.Connect(IPAddress.Parse(_gui.tbClientIP.Text.Trim()), PORT);
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            _clientSocket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveMessage, _clientSocket);
            while (!_clientConnected)
            {
                SendUsername();
                Console.WriteLine(_clientConnected);
                Thread.Sleep(500);
            }
            Console.WriteLine(_clientConnected);
        }
        public static void Disconnect()
        {
            SendCommand("!exit");
            _clientSocket.Close();
            _clientSocket.Close();
            _clientConnected = false;
        }
        public static void ReceiveMessage(IAsyncResult AR)
        {
            Console.WriteLine("Received Sth");
            Socket serverSocket = (Socket)AR.AsyncState;
            int received;

            try
            {
                received = serverSocket.EndReceive(AR);
            }
            catch (SocketException)
            {
                serverSocket.Close();
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);
            if (text.Substring(0, 1) == "!")
            {
                ValidateCommand(text, serverSocket);
            }
            else
            {
                _gui.tbClientOutput.Invoke((MethodInvoker)delegate ()
                {
                    _gui.tbClientOutput.Text += text;
                });
            }
            _clientSocket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveMessage, _clientSocket);
        }
        public static void SendMessage()
        {
            byte[] buffer = Encoding.ASCII.GetBytes("[" + _username + "] " + _gui.tbClientInput.Text + "\r\n");
            _clientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
        public static void SendCommand(String command)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(command);
            _clientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
        public static void SendUsername()
        {
            byte[] buffer = Encoding.ASCII.GetBytes("Username:" + Client._username);
            _clientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
        public static void ValidateCommand(String command, Socket serverSocket)
        {
            if (command == "!accepted")
            {
                Console.WriteLine("command validation reached");
                _clientConnected = true;
                _gui.tbClientOutput.Invoke((MethodInvoker)delegate ()
                {
                    _gui.tbClientOutput.Text += "[Server] Connected\r\n";
                });
            }
        }
    }
}