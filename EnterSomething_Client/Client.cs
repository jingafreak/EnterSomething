using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

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
                    if (_gui.tbClientIP.Text.ToLower().Trim() == "loopback")
                    {
                        _clientSocket.Connect(IPAddress.Parse("127.0.0.1"), PORT);
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
            while (!_clientConnected) {
                SendUsername();
            }
        }
        public static void Disconnect()
        {
            SendCommand("!exit");
            _clientSocket.Close();
            _clientSocket.Close();
        }
        public static void ReceiveMessage(IAsyncResult AR)
        {
            Socket current = (Socket)AR.AsyncState;
            int received;

            try
            {
                received = current.EndReceive(AR);
            }
            catch (SocketException)
            {
                current.Close();
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);
            if (text.Substring(0, 1) == "!")
            {
                ValidateCommand(text, current);
            }
            else
            {
                _gui.tbClientOutput.Text += text;
            }
            current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveMessage, current);
        }
        public static void SendMessage()
        {
            byte[] buffer = Encoding.ASCII.GetBytes(_gui.tbClientInput.Text + "\r\n");
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
                _gui.tbClientOutput.Text += "[Server] Connected\r\n";
                _clientConnected = true;
            }
        }
    }
}