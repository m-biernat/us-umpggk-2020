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
                    move = GetMove(0, 0, 3, 0, pawns);
                    stage++;
                    break;
            }

            return move;
        }
    }
}
