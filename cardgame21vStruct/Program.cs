using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardgame21vStruct
{
    struct Game
    {
        public int index;
        public Card[] cards;
        public int PointsPlayer1;
        public int PointsPlayer2;
        public string MorePlayer1;
        
        public void TakeP1()
        {
            int PointsPlayer1 = 0;
            PointsPlayer1 += cards[index];
            Console.WriteLine($"You took card {cards[index]}");
            index++;
            PointsPlayer1 += cards[index];
            Console.WriteLine($"You took card {cards[index]}");
            index++;
            Console.WriteLine($"Your summa = {PointsPlayer1} of 21 ");
        }
        public void TakeP2()
        {
            int PointsPlayer2 = 0;
            PointsPlayer2 += cards[index];
            index++;
            PointsPlayer2 += cards[index];
            index++;
        }
        public void Comparison()
        {
            if (PointsPlayer1 == 21)
            {
                Console.WriteLine("You took 21 points, you won!");
            }
            if (PointsPlayer2 == 21)
            {
                Console.WriteLine("Computer took 21 points, you lose!");
            }
            if (PointsPlayer1 == 21 && PointsPlayer2 == 21)
            {
                Console.WriteLine("DRAW!!!");
            }
            Console.ReadKey();
        }
        public void MoreP1()
        {
            while (MorePlayer1 == "1" && PointsPlayer1 < 21)
            {
                while (MorePlayer1 != "1" || MorePlayer1 != "2")
                {
                    Console.WriteLine("Do you want take more?");
                    Console.WriteLine("Yes - 1 / No - 2");
                    MorePlayer1 = Console.ReadLine();
                    if (MorePlayer1 == "1" || MorePlayer1 == "2")
                    {
                        break;
                    }
                }
                if (MorePlayer1 == "1")
                {

                    PointsPlayer1 += cards[index];
                    index++;
                    if (PointsPlayer1 > 21)
                    {
                        Console.WriteLine($"You took card, your summa = {PointsPlayer1}");
                        Console.WriteLine("You have more than 21, you lose!");
                        break;
                    }
                    if (PointsPlayer1 == 21)
                    {
                        break;
                    }
                    Console.WriteLine($"You took card, your summa = {PointsPlayer1}");
                }

            }
        }
        public void MoreP2()
        {
            while (PointsPlayer2 < 16)
            {
                PointsPlayer2 += cards[index];
                index++;
                if (PointsPlayer2 > 21)
                {
                    Console.WriteLine($"Computer took card, his summa = {PointsPlayer2}");
                    Console.WriteLine("Computer have more than 21, VICTORY!!!");
                    break;
                }
                if (PointsPlayer2 == 21)
                {
                    break;
                }
            }
        }
        public void Comparison2()
        {
            if (PointsPlayer1 > PointsPlayer2 && PointsPlayer1 <= 21)
            {
                Console.WriteLine($"You have {PointsPlayer1} points, computer have {PointsPlayer2} points.");
                Console.WriteLine("VICTORY!!!");
            }
            else if (PointsPlayer2 > PointsPlayer1 && PointsPlayer2 <= 21)
            {
                Console.WriteLine($"You have {PointsPlayer1} points, computer have {PointsPlayer2} points.");
                Console.WriteLine("You LOSE!!!");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Game BJ = new Game();
            Cards Game1 = new Cards();
            BJ.index = 0;
            BJ.cards = Game1.Deck();
            BJ.PointsPlayer1 = 0;
            BJ.PointsPlayer2 = 0;
            Game1.Sort();
            string NewGame = "1";
            Random Player = new Random();
            while (NewGame == "1")
            {
                var a = (Player.Next(0, 2));
                if (a == 0)
                {

                    Console.WriteLine("You take cards first");
                    Console.ReadKey();
                    BJ.TakeP1();
                    BJ.TakeP2();
                    BJ.Comparison();
                    Console.ReadKey();
                    BJ.MorePlayer1 = "1";
                    BJ.MoreP1();
                    BJ.MoreP2();
                    BJ.Comparison2();
                }
                else
                {
                    Console.WriteLine("Computer take cards first");
                    Console.ReadKey();
                    BJ.TakeP2();
                    BJ.TakeP1();
                    BJ.Comparison();
                    Console.ReadKey();
                    BJ.MoreP2();
                    BJ.MorePlayer1 = "1";
                    BJ.MoreP1();
                    BJ.Comparison2();
                }
                while (NewGame != "1" || NewGame != "2")
                {
                    Console.WriteLine("Do you want start new game?");
                    Console.WriteLine("Yes - 1 / No - 2");
                    NewGame = Console.ReadLine();
                    if (NewGame == "1" || NewGame == "2")
                    {
                        break;
                    }
                }
                
            }
        }
    }
}
