using System;
using System.Collections.Generic;

namespace umpggk_biernat_hosumbek
{
    class Chessboard
    {
        public Field[,] Fields { get; private set; }

        public List<Pawn> Pawns { get; private set; }
        public List<Pawn> Whites { get; private set; }
        public List<Pawn> Blacks { get; private set; }

        public Chessboard()
        {
            Fields = new Field[5, 5];
            CreateFields();

            Pawns = new List<Pawn>();
            Whites = CreatePawns("white");
            Blacks = CreatePawns("black");
        }

        private void CreateFields()
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (row == 2 && col == 2)
                        Fields[row, col] = new Field(FieldType.kingsValley, null);
                    else
                        Fields[row, col] = new Field();
                }
            }
        }

        private List<Pawn> CreatePawns(string color)
        {
            List<Pawn> pawnsOfColor = new List<Pawn>();

            for (int i = 0; i < 5; i++)
            {
                Pawn pawn;

                if (i < 4)
                    pawn = new Pawn(PawnType.pawn, color);
                else
                    pawn = new Pawn(PawnType.king, color);

                Pawns.Add(pawn);
                pawnsOfColor.Add(pawn);
            }

            return pawnsOfColor;
        }

        public void Reset()
        {
            foreach (var field in Fields)
                field.Pawn = null;

            int col = 0, row = 0;

            foreach (var pawn in Pawns)
            {
                if (col == 2)
                    col++;

                if (col == 5)
                {
                    row = row == 0 ? row = 4 : row = 0;

                    Fields[row, 2].Pawn = pawn;
                    pawn.position = new int[] { row, 2 };

                    col = 0;
                    row = 4;
                }
                else
                {
                    Fields[row, col].Pawn = pawn;
                    pawn.position = new int[] { row, col };
                    col++;
                }
            }
        }

        public void Move(int[] from, int[] to)
        {
            Pawn pawn = Fields[from[0], from[1]].Pawn;
            Fields[from[0], from[1]].Pawn = null;

            Fields[to[0], to[1]].Pawn = pawn;
            pawn.position = to;
        }
    }
}
