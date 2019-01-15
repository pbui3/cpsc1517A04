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
            Die blah = new Die(6, "black", 4);
            blah.FaceValue = 10;
            Console.WriteLine(blah.FaceValue);
            Console.ReadLine();
            Die blob = new Die();
            Console.WriteLine(blob.FaceValue);
            Console.ReadLine();
        }
    }
}
