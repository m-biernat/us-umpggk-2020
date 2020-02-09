using System;
using System.Collections.Generic;

namespace umpggk_biernat_hosumbek
{
    class Game
    {
        private Connection connection;
        public Chessboard chessboard;

        public string color;

        private List<Pawn> pawns;

        private Pawn king;
        private bool check;

        private Random rnd;

        private Strategy strategy;

        public Game(Connection connection)
        {
            this.connection = connection;
            chessboard = new Chessboard();

            Move.chessboard = chessboard;
            Move.OnCheck += OnCheck;

            Message.OnStart += OnStart;
            Message.OnMove += OnMove;

            rnd = new Random();
        }

        private void OnCheck(string color)
        {
            if (this.color == color)
                check = true;
        }

        private void OnStart(string color)
        {
            this.color = color;
            chessboard.Reset();

            if (color == "white")
            {
                pawns = chessboard.Whites;
                strategy = new WhiteStrategy(this);
            }
            else
            {
                pawns = chessboard.Blacks;
                strategy = new BlackStrategy(this);
            }

            king = pawns[4];
            check = false;

            if (color == "white")
            {
                List<Pawn> startingPawns = new List<Pawn>();

                for (int i = 0; i < 4; i++)
                { 
                    startingPawns.Add(pawns[i]); 
                }

                GetAllAvailableMoves(startingPawns);
                SendNextMove(startingPawns);

                //Debug.Draw(chessboard);
            }
        }

        private void OnMove(string from, string to)
        {
            chessboard.Move(Message.ParseIn(from), Message.ParseIn(to));

            GetAllAvailableMoves(pawns);
            SendNextMove(pawns);

            //Debug.Draw(chessboard);
        }

        private void SendNextMove(List<Pawn> pawns)
        {
            List<Pawn> pawnsWithMoves = new List<Pawn>();

            foreach(var pawn in pawns)
            {
                if (pawn.possibleMoves.Count > 0)
                    pawnsWithMoves.Add(pawn);
            }

            Pawn selected;
            int[] move;

            Move nextMove = strategy.NextMove(pawnsWithMoves);

            if (nextMove != null)
            {
                selected = nextMove.pawn;
                move = nextMove.position;
            }
            else
            {
                if (!check)
                {
                    selected = pawnsWithMoves[rnd.Next(0, pawnsWithMoves.Count)];
                    move = selected.possibleMoves[rnd.Next(0, selected.possibleMoves.Count)];
                }
                else
                {
                    selected = king;
                    move = new int[] { 2, 2 };
                }
            }

            connection.Send(Message.ParseOut(selected.position), Message.ParseOut(move));
            chessboard.Move(selected.position, move);
        }

        private void GetAllAvailableMoves(List<Pawn> pawns)
        {
            foreach (var pawn in pawns)
            {
                pawn.possibleMoves.Clear();
                Move.CheckDirection(pawn, 0, 1);
                Move.CheckDirection(pawn, 0, -1);
                Move.CheckDirection(pawn, 1, 0);
                Move.CheckDirection(pawn, -1, 0);
                Move.CheckDirection(pawn, 1, 1);
                Move.CheckDirection(pawn, 1, -1);
                Move.CheckDirection(pawn, -1, 1);
                Move.CheckDirection(pawn, -1, -1);
                
                //Debug.PrintMoves(pawn);
            }
        }
    }
}
