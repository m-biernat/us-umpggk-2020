using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umpggk_biernat_hosumbek
{
    class Debug
    {
        public static void Draw(Chessboard cb)
        {
            Console.WriteLine("     0  1  2  3  4");
            Console.WriteLine("   +---------------+");

            for (int i = 0; i < 5; i++)
            {
                Console.Write(" " + i + " |");

                for (int j = 0; j < 5; j++)
                {
                    if (!cb.Fields[i, j].IsEmpty())
                    {
                        Pawn pawn = cb.Fields[i, j].Pawn;

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
                        if (cb.Fields[i, j].Type == FieldType.neutral)
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
