using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    class Program
    {
        static void Main(string[] args)
        {
            Turn blah = new Turn();
            blah.P1Roll();
            blah.P2Roll();
            blah.Compare();
            Console.ReadLine();
        }
    }
}
