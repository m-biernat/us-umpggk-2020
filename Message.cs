using System;

namespace umpggk_biernat_hosumbek
{
    class Message
    {
        public delegate void OnFinishDelegate();
        public static OnFinishDelegate OnFinish;

        public delegate void OnStartDelegate(string color);
        public static OnStartDelegate OnStart;

        public delegate void OnMoveDelegate(string from, string to);
        public static OnMoveDelegate OnMove;

        public static void Process(string data)
        {
            string[] msg = data.Split(' ');

            switch (msg[0])
            {
                case "200":
                    Console.WriteLine("\n[MATCH STARTED] as " + msg[1]);
                    OnStart(msg[1]);
                    break;

                case "210":
                    Console.WriteLine("[SENT MOVE] " + msg[1] + " -> " + msg[2]);
                    break;

                case "220":
                    Console.WriteLine("[RECIEVED MOVE] " + msg[1] + " -> " + msg[2]);
                    OnMove(msg[1], msg[2]);
                    break;

                case "230":
                    Console.WriteLine("[MATCH RESULT] VICTORY (rules)");
                    break;

                case "231":
                    Console.WriteLine("[MATCH RESULT] VICTORY (time limit)");
                    break;

                case "232":
                    Console.WriteLine("[MATCH RESULT] VICTORY (enemy disconnected)");
                    break;

                case "240":
                    Console.WriteLine("[MATCH RESULT] DEFEAT (rules)");
                    break;

                case "241":
                    Console.WriteLine("[MATCH RESULT] DEFEAT (time limit)");
                    break;

                case "250":
                    Console.WriteLine("[MATCH RESULT] TIE");
                    break;

                case "299":
                    Console.WriteLine("\n[TOURNAMENT] The tournament has ended - rank: " + msg[1]);
                    OnFinish();
                    break;

                case "500":
                    Console.WriteLine("[SERVER] Attempting to connect " + msg[1]);
                    break;

                case "550":
                    Console.WriteLine("[SERVER] Connection successful!");
                    break;

                case "555":
                    Console.WriteLine("\n[SERVER] Connected as " + data.Remove(0, 4));
                    break;

                case "700":     
                    Console.WriteLine("\n[SYSTEM ERROR] " + data.Remove(0, 4));
                    OnFinish();
                    break;

                case "999":
                    Console.WriteLine("[COMMAND ERROR] " + data.Remove(0, 4));
                    break;

                default:
                    Console.WriteLine("[RECIEVED DATA] " + data);
                    break;
            }
        }

        public static int[] ParseIn(string data)
        {
            int[] arr = { data[2] - 48, data[0] - 48 };

            return arr;
        }

        public static string ParseOut(int[] position)
        {
            return position[1] + "," + position[0];
        }
    }
}
