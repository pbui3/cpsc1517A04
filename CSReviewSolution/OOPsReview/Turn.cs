using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    class Turn
    {
        public List<int> _listOfValuesP1 { get; private set; }
        public List<int> _listOfValuesP2 { get; private set; }
        public int turnCounter { get; private set; }

        public Turn()
        {
            _listOfValuesP1 = new List<int>();
            _listOfValuesP2 = new List<int>();
        }

        public void P1Roll()
        {
            Die roll = new Die();
            _listOfValuesP1.Add(roll.FaceValue);
            Console.WriteLine(_listOfValuesP1[turnCounter]);
        }
        public void P2Roll()
        {
            Die roll = new Die();
            _listOfValuesP2.Add(roll.FaceValue);
            Console.WriteLine(_listOfValuesP2[turnCounter]);
        }
        public void Compare()
        {
            if (_listOfValuesP1[turnCounter] == _listOfValuesP2[turnCounter])
            {
                Console.WriteLine("Draw");
            }
            else
            {
                if (_listOfValuesP1[turnCounter] > _listOfValuesP2[turnCounter])
                {
                    Console.WriteLine("Player 1 Wins!");
                }
                else
                {
                    Console.WriteLine("Player 2 Wins!");
                }
            }
            turnCounter++;
        }
    }
}
