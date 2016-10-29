using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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
                _serverSocket.Listen(10);
                _serverSocket.BeginAccept(AcceptUser, null);

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
            Socket clientSocket;
            try
            {
                clientSocket = _serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
                return;
            }
            _serverSocket.BeginAccept(AcceptUser, null);
            clientSocket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveUsername, clientSocket);
        }
        private static void ReceiveUsername(IAsyncResult AR)
        {
            Socket clientSocket = (Socket) AR.AsyncState;
            int received;

            try
            {
                received = clientSocket.EndReceive(AR);
            }
            catch (SocketException)
            {
                clientSocket.Close();
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);
            if (text.Substring(0, 9) == "Username:")
            {
                _users.Add(new User(clientSocket, text.Substring(9)));
                _gui.tbServerOutput.Invoke((MethodInvoker) delegate ()
                {
                    _gui.tbServerOutput.Text += "[Server] User " + text.Substring(9) + " connected\r\n";
                });
                SendCommand("!accepted", clientSocket);
                clientSocket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveMessage, clientSocket);
            }
            else
            {
                clientSocket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveUsername, clientSocket);
            }
        }
        private void editText()
        {

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
            }
            else
            {
                _gui.tbServerOutput.Invoke((MethodInvoker)delegate ()
                {
                    _gui.tbServerOutput.Text += text;
                });
            }
            current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveMessage, current);
        }
        public static void SendCommand(String command, Socket clientSocket)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(command);
            clientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
        public static void ValidateCommand(String command, Socket userSocket)
        {
            if (command == "!exit") {
                foreach (User user in _users)
                {
                    if (user.getSocket() == userSocket)
                    {
                        _gui.tbServerOutput.Invoke((MethodInvoker)delegate ()
                        {
                            _gui.tbServerOutput.Text += "[Server] User " + user.getUsername() + " disconnected\r\n";
                        });
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