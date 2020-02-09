using System.Collections.Generic;

namespace umpggk_biernat_hosumbek
{
    class BlackStrategy : Strategy
    {
        public BlackStrategy(Game game) : base(game) { }

        public override Move NextMove(List<Pawn> pawns)
        {
            Move move = null;

            switch (stage)
            {
                case 1:
                    move = GetMove(4, 0, 1, 0, pawns);
                    if (move == null)
                    {
                        move = GetMove(4, 4, 1, 4, pawns);
                        strategyNumber = 2;
                    }
                    stage++;
                    break;

                case 2:
                    if (chessboard.Fields[3, 2].isEmpty())
                    {
                        if (chessboard.Fields[1, 2].isEmpty() || chessboard.Fields[1, 2].Pawn.Type == PawnType.pawn)
                        {
                            if (strategyNumber == 1)
                                move = GetMove(1, 0, 3, 2, pawns);
                            else
                                move = GetMove(1, 4, 3, 2, pawns);

                            stage = 0;
                        }
                        else
                        {
                            if (strategyNumber == 1)
                            {
                                move = GetMove(0, 2, 2, 4, pawns);
                                stage = 3;
                            }
                            else
                            {
                                move = GetMove(0, 2, 2, 0, pawns);
                                stage = 3;
                            }
                        }
                    }
                    else
                        stage = 0;
                    break;

                case 3:
                    if (strategyNumber == 1)
                    {
                        if (chessboard.Fields[2, 3].isEmpty())
                            move = GetMove(4, 3, 2, 1, pawns);
                    }
                    else
                    {
                        if (chessboard.Fields[2, 1].isEmpty())
                            move = GetMove(4, 1, 2, 3, pawns);
                    }
                    stage = 0;
                    break;
            }

            return move;
        }
    }
}
