using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardgame21vStruct
{
    public enum Points
    {
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 2,
        Lady = 3,
        King = 4,
        Ace = 11,

    }
    struct Card
    {
        public Points points;
    }
    struct Cards
    {
        public Card[] Deck()
        {
            Card[] Cards = new Card[36];
            int i = 0;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 2; y <= 11; y++)
                {
                    if (y != 5)
                    {
                        Cards[i] = (new Card { points = (Points)x });
                        i++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return Cards;
        }
        public Card[] Sort()
        {
            Random random = new Random();
            Card[] Cards = Deck();
            for (int i = Cards.Length - 1; i >= 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = Cards[j];
                Cards[j] = Cards[i];
                Cards[i] = temp;
            }
            return Cards;
        }
    }
}
