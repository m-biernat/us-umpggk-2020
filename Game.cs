using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umpggk_biernat_hosumbek
{
    class Game
    {
        private Connection connection;
        private Chessboard chessboard;

        private string color;

        public Game(Connection connection)
        {
            this.connection = connection;
            chessboard = new Chessboard();

            Message.OnStart += OnStart;
            Message.OnMove += OnMove;
        }

        private void OnStart(string color)
        {
            this.color = color;
            chessboard.Reset();
        }

        private void OnMove(string from, string to)
        {
            chessboard.Move(Message.ParseIn(from), Message.ParseIn(to));


            int[] arrF = { 4, 4 };
            int[] arrT = { 1, 4 };

            connection.Send(Message.ParseOut(arrF), Message.ParseOut(arrT));
            //chessboard.Move(arrF, arrT);


            Debug.Draw(chessboard);
        }
    }
}
