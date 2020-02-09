using System.Collections.Generic;

namespace umpggk_biernat_hosumbek
{
    abstract class Strategy
    {
        protected Game game;
        protected Chessboard chessboard;

        protected int stage;
        protected int strategyNumber;

        public Strategy(Game game)
        {
            this.game = game;
            chessboard = game.chessboard;

            stage = 1;
            strategyNumber = 1;
        }

        public abstract Move NextMove(List<Pawn> pawns);

        protected bool isMovePossible(Move move, List<Pawn> pawns)
        {
            bool isPawnOnTheList = false;
            bool isMoveOnTheList = false;

            foreach (var pawn in pawns)
            {
                if (pawn == move.pawn)
                    isPawnOnTheList = true;
            }

            if (isPawnOnTheList)
            {
                foreach (var position in move.pawn.possibleMoves)
                {
                    if (position[0] == move.position[0] && position[1] == move.position[1])
                    {
                        isMoveOnTheList = true;
                    }
                }

                return isMoveOnTheList;
            }
            else
                return false;
        }

        protected Move GetMove(int fromRow, int fromCol, int toRow, int toCol, List<Pawn> pawns)
        {
            Move move = new Move(chessboard.Fields[fromRow, fromCol].Pawn, new int[2] { toRow, toCol });

            if (move.pawn != null)
            {
                if (isMovePossible(move, pawns))
                {
                    return move;
                }
                else
                    return null;
            }
            else
                return null;
        }
    }
}
