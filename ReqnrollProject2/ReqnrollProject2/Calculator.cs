using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject2
{
    public class Calculator
    {
        public int FirstNumber { get; set; }
    public int SecondNumber  { get; set; }

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }

        public int Subtract()
        {
            return FirstNumber - SecondNumber;
        }

        public int Multiply()
        {
            return FirstNumber * SecondNumber;
        }

        public int Divide()
        {
            if (FirstNumber == 0)
            {
                Console.WriteLine("Invalid number");
            }

            return FirstNumber / SecondNumber;
        }
    }
}
