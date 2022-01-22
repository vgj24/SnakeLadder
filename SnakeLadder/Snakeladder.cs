using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder
{
    internal class Snakeladder
    {
        private static Dictionary<int, int> snl = new Dictionary<int, int>()
        {
            {4, 14},
            {9, 31},
            {17, 7},
            {20, 38},
            {28, 84},
            {40, 59},
            {51, 67},
            {54, 34},
            {62, 19},
            {63, 81},
            {64, 60},
            {71, 91},
            {87, 24},
            {93, 73},
            {95, 75},
            {99, 78},
        };
        private static Random random = new Random();
        private const bool sixthrowagain = true;

        public static int turn(int player, int dice)
        {
            while (true)
            {
                int rollcheck = random.Next(1, 6);
                Console.WriteLine("player {0}, dice {1}, rollcheck {2} ",player,dice,rollcheck);
                if (dice + rollcheck > 100)
                {
                    Console.WriteLine("but can not move");
                }
                else
                {
                    dice += rollcheck;

                    Console.WriteLine("moves to dice {0} ", dice);
                    if (dice == 100)
                    {
                        return 100;
                    }
                    int next = dice;
                    if (snl.ContainsKey(next))
                    {
                        dice = snl[next];
                    }
                    if (next < dice)
                    {
                        Console.WriteLine("its ladder climb upto {0}", next);
                        if (next == 100)
                            return 100;
                        dice = next;
                    }
                    else if (next > dice)
                    {
                        Console.WriteLine("its snake get down upto {0}", next);
                    }
                }

                if (rollcheck < 6 || !sixthrowagain)
                {
                    Console.WriteLine("its 6 roll again");
                    return dice;
                }
            }
        }


        public static void snakeLadder()
        {
            int[] player = {1,1};
            while (true)
            {
                for (int i = 0; i < player.Length; i++)
                {
                    int track = turn(i + 1, player[i]);
                    if (track == 100)
                    {
                        Console.WriteLine("player {0} wins ",i + 1);
                        return;
                    }
                    player[i]=track;
                    Console.WriteLine();
                }
            }
        }
    }

}


