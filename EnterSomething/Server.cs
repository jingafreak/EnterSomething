using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace EnterSomething
{
    public class Server
    {
        private static Socket _serverSocket;
        public static bool _serverOnline;
        private const int PORT = 3131;
        private const int BUFFER_SIZE = 2048;
        private static byte[] buffer = new byte[BUFFER_SIZE];

        private static List<User> _users = new List<User>();
        private static GUI _gui;

        public static void SetupServer(GUI gui)
        {
            Server._gui = gui;
            if (!_serverOnline)
            {
                _gui.tbServerOutput.Text += "[Server] Setting up Server...\r\n";
                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT));
                _serverSocket.Listen(0);
                Thread tAcceptUserLoop = new Thread(delegate ()
                {
                    while (true)
                    {
                        new Thread(delegate ()
                        {
                            _serverSocket.BeginAccept(AcceptUser, null);
                        });
                    }
                });
                _serverOnline = true;
                _gui.tbServerOutput.Text += "[Server] ...Server mounted\r\n";
            } else
            {
                _gui.tbServerOutput.Text += "[Server] Server allready mounted\r\n";
            }
        }
        public static void ShutdownServer()
        {
            foreach (User user in _users)
            {
                user.getSocket().Shutdown(SocketShutdown.Both);
                user.getSocket().Close();
            }
            _serverSocket.Close();
            _serverOnline = false;
            _gui.tbServerOutput.Text += "[Server] Server Shutdown successfull\r\n";
        }
        private static void AcceptUser(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                socket = _serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
                return;
            }
            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveUsername, socket);
        }
        private static void ReceiveUsername(IAsyncResult AR)
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
            if (text.Substring(0, 9) == "Username:")
            {
                _users.Add(new User(current, text.Substring(9)));
                _gui.tbServerOutput.Text += "[Server] User " + text.Substring(9) + " connected\r\n";
                current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveMessage, current);
            }
            else
            {
                _serverSocket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveUsername, current);
            }
        }
        private static void ReceiveMessage(IAsyncResult AR)
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
                foreach (User user in _users)
                {
                    if (user.getSocket() == current)
                    {
                        Console.WriteLine("[Server] User " + user.getUsername() + " disconnected\r\n");
                        _users.Remove(new User(current, user.getUsername()));
                    }
                }
                current.Close();
                
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);
            if (text.Substring(0, 1) == "!")
            {
                ValidateCommand(text, current);
            } else
            {
                _gui.tbServerOutput.Text += text;
                current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveMessage, current);
            }
        }
        public static void ValidateCommand(String command, Socket userSocket)
        {
            if (command == "!exit") {
                foreach (User user in _users)
                {
                    if (user.getSocket() == userSocket)
                    {
                        Console.WriteLine("[Server] User " + user.getUsername() + " disconnected\r\n");
                        _users.Remove(new User(userSocket, user.getUsername()));
                    }
                }
                userSocket.Close();
            }
        }
    }

    public class User
    {
        private Socket socket;
        private String username;
        public User(Socket socket, String username)
        {
            this.socket = socket;
            this.username = username;
        }
        public Socket getSocket()
        {
            return socket;
        }
        public String getUsername()
        {
            return username;
        }
    }
}