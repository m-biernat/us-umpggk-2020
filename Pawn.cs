using System.Collections.Generic;

namespace umpggk_biernat_hosumbek
{
    class Pawn
    {
        public PawnType Type { get; private set; }
        public string Color { get; private set; }

        public int[] position;

        public List<int[]> possibleMoves;

        public Pawn(PawnType type, string color)
        {
            Type = type;
            Color = color;

            position = new int[2];
            possibleMoves = new List<int[]>();
        }
    }

    enum PawnType
    {
        pawn,
        king
    }
}
