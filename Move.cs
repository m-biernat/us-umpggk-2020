namespace umpggk_biernat_hosumbek
{
    class Move
    {
        public static Chessboard chessboard;

        public delegate void OnCheckDelegate(string color);
        public static OnCheckDelegate OnCheck;

        public static void CheckDirection(Pawn pawn, int rowDir, int colDir)
        {
            int[] pos = { pawn.position[0], pawn.position[1] };

            int row = pos[0], col = pos[1];

            int dist = 0;

            row += rowDir;
            col += colDir;

            while (!(row > 4 || row < 0 || col > 4 || col < 0 || !chessboard.Fields[row, col].isEmpty()))
            {
                pos[0] = row;
                pos[1] = col;

                row += rowDir;
                col += colDir;
                dist++;
            }

            if (dist > 0)
            {
                if (chessboard.Fields[pos[0], pos[1]].Type == FieldType.kingsValley)
                {
                    if (pawn.Type != PawnType.pawn)
                        OnCheck(pawn.Color);
                    else
                        return;
                }

                pawn.possibleMoves.Add(pos);
            }
        }
    }
}
