using System;

namespace umpggk_biernat_hosumbek
{
    class Program
    {
        public static string playerName = "biernat-hosumbek";

        static void Main(string[] args)
        {
            Connection con;

            if (args.Length > 0)
                con = new Connection(args[0], int.Parse(args[1]));
            else
                con = new Connection();

            do
            {
                Console.Clear();

                con.Connect();
                
                Console.Write("\nDo you want to reconnect? (y/n): ");
            } 
            while (Console.ReadLine() == "y");

            Console.WriteLine("\nThe program has exited with code " + Environment.ExitCode);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
