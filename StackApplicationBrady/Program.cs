/**************************************************************
* Name        : StackApplicationBrady
* Author      : Kabrina Brady
* Created     : 2/9/2021
* Course      : Data Structures
* Version     : 1.0
* OS          : Windows XX
* Copyright   : This is my own original work based on
*               specifications issued by our instructor
* Description : This program overall description here
*               Input:  list and describe
*               Output: list and describe
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or 
* unmodified. I have not given other fellow student(s) access to
* my program.         
***************************************************************/


using System;
using System.Collections;

namespace StackApplicationBrady
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prints solutions
            Console.WriteLine("Infix: 2 + 3 * 4");
            Console.WriteLine("Postfix: 234 * +\n");

            Console.WriteLine("Infix: a * b + 5");
            Console.WriteLine("Postfix: ab * 5 +\n");

            Console.WriteLine("Infix: (1 + 2) * 7");
            Console.WriteLine("Postfix: 12 + 7 *\n");

            Console.WriteLine("Infix: a * b / c");
            Console.WriteLine("Postfix: ab * c /\n");

            Console.WriteLine("Infix: (a / (b - c + d)) * (e - a) * c");
            Console.WriteLine("Postfix: abc - d +/ ea - *c *\n");

            Console.WriteLine("Infix: a / b - c + d * e - a * c");
            Console.WriteLine("Postfix: ab / c - de * +ac * +-\n");

            Console.WriteLine("Enter infix notation with no spaces:");
            string infix = Console.ReadLine();

            Converter c = new Converter();
            string postfix = c.Convert(infix);
            Console.WriteLine(postfix);
        }
    }
}
