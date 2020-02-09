using System.Collections.Generic;

namespace umpggk_biernat_hosumbek
{
    class WhiteStrategy : Strategy
    {
        public WhiteStrategy(Game game) : base(game) { }

        public override Move NextMove(List<Pawn> pawns)
        {
            Move move = null;

            switch (stage)
            {
                case 1:
                    move = GetMove(0, 0, 3, 0, pawns);
                    stage++;
                    break;

                case 2:
                    if (chessboard.Fields[3, 2].isEmpty())
                    {
                        move = GetMove(3, 0, 1, 2, pawns);
                        stage = 0;
                    }   
                    else
                    {
                        move = GetMove(4, 2, 2, 4, pawns);
                        stage++;
                    }
                    break;

                case 3:
                    move = GetMove(0, 3, 2, 1, pawns);
                    stage = 0;
                    break;
            }

            return move;
        }
    }
}
