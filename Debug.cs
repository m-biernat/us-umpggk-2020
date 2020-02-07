using System;

namespace umpggk_biernat_hosumbek
{
    class Debug
    {
        public static void Draw(Chessboard chessboard)
        {
            Console.WriteLine("     0  1  2  3  4");
            Console.WriteLine("   +---------------+");

            for (int i = 0; i < 5; i++)
            {
                Console.Write(" " + i + " |");

                for (int j = 0; j < 5; j++)
                {
                    if (!chessboard.Fields[i, j].isEmpty())
                    {
                        Pawn pawn = chessboard.Fields[i, j].Pawn;

                        if (pawn.Color == "white")
                        {
                            if (pawn.Type == PawnType.pawn)
                                Console.Write(" w ");
                            else
                                Console.Write(" W ");
                        }
                        else
                        {
                            if (pawn.Type == PawnType.pawn)
                                Console.Write(" b ");
                            else
                                Console.Write(" B ");
                        }
                    }
                    else
                    {
                        if (chessboard.Fields[i, j].Type == FieldType.neutral)
                            Console.Write(" . ");
                        else
                            Console.Write(" # ");
                    }
                }
                Console.WriteLine("|");
            }

            Console.WriteLine("   +---------------+");
        }

    }
}
