using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace EnterSomething
{
    public class Client
    {
        private static Socket _clientSocketReceive;
        private static Socket _clientSocketSend;
        private const int PORT = 3131;
        private const int BUFFER_SIZE = 2048;
        private static byte[] buffer = new byte[BUFFER_SIZE];
        private static String _username;

        private static GUI _gui;

        public static void Connect(GUI gui)
        {
            Client._gui = gui;
            Client._username = _gui.tbClientUsername.Text;
            _clientSocketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            while (!_clientSocketSend.Connected)
            {
                try
                {
                    if (_gui.tbClientIP.Text.ToLower().Trim() == "loopback")
                    {
                        _clientSocketSend.Connect(IPAddress.Parse("127.0.0.1"), PORT);
                    }
                    _clientSocketSend.Connect(IPAddress.Parse(_gui.tbClientIP.Text.Trim()), PORT);
                }
                catch (SocketException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            SendUsername();
            Thread.Sleep(500);
            _gui.tbClientOutput.Text += "[Server] Connected\r\n";
            Thread tListenLoop = new Thread(delegate ()
            {
                _clientSocketReceive = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _clientSocketReceive.Bind(new IPEndPoint(IPAddress.Any, PORT));
                while (true)
                {
                    _clientSocketReceive.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, AcceptServer, _clientSocketReceive);
                }
            });
        }
        public static void Disconnect()
        {
            SendCommand("!exit");
            _clientSocketSend.Close();
            _clientSocketReceive.Close();
        }
        public static void AcceptServer(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                socket = _clientSocketReceive.EndAccept(AR);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
                return;
            }
            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveMessage, socket);
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
                // Don't shutdown because the socket may be disposed and its disconnected anyway.
                current.Close();
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);
            _gui.tbClientOutput.Text += text;
            current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveMessage, current);
        }
        public static void SendMessage()
        {
            byte[] buffer = Encoding.ASCII.GetBytes(_gui.tbClientInput.Text + "\r\n");
            _clientSocketSend.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
        public static void SendCommand(String command)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(command);
            _clientSocketSend.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
        public static void SendUsername()
        {
            byte[] buffer = Encoding.ASCII.GetBytes("Username:" + Client._username);
            _clientSocketSend.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
    }
}