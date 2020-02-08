using System;
using SocketLibrary;

namespace umpggk_biernat_hosumbek
{
    class Connection
    {
        private ConnectedSocket socket;

        private string ipAddress;
        private int port;

        private bool finished;

        public Connection(string ipAddress = "127.0.0.1", int port = 6789)
        {
            this.ipAddress = ipAddress;
            this.port = port;

            Message.OnFinish += OnFinish;
        }

        public void Connect()
        {
            finished = false;

            try {
                Message.Process("500 " + ipAddress + ":" + port);
                socket = new ConnectedSocket(ipAddress, port);
                Message.Process("550");

                socket.Send("100 " + Program.playerName + "\n");
                Message.Process("555 " + Program.playerName);

                while (!finished)
                {
                    try {
                        Message.Process(socket.Receive().Trim());
                    }
                    catch (Exception e) {
                        Message.Process("700 " + e.Message);
                    }
                }
            }
            catch (Exception e) {
                Message.Process("700 " + e.Message);
            }
        }

        public void Send(string from, string to)
        {
            string data = "210 " + from + " " + to + "\n";
            socket.Send(data);
            Message.Process(data);
        }

        private void OnFinish()
        {
            finished = true;
        }
    }
}
