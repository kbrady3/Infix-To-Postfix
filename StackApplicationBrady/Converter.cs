using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StackApplicationBrady
{
    public class Converter
    {
        // Loop through each item X in the input string.
        // If X is letter/number, print it.
        // If operator, add to operator stack.
        // While X is operator, check it against operator[TOP] to see if it has a higher or equal precedence.
        //     IF X HIGHER OR EQUAL PRECEDENCE, pop TOP and add TOP to output stack.
        //     ELSE, push X to operator stack.
        public bool StackEmpty(Stack s) { if(s.Count == 0) { return true; } else { return false; } }
        public string Top(Stack s) { if (s.Count != 0) { return s.Peek().ToString(); } else { return null; } }
        public string Convert(string infix)
        {
            string output = "";
            Stack stack = new Stack();

            foreach (char c in infix)
            {
                if (Char.IsNumber(c) || Char.IsLetter(c))
                {
                    output += c;
                }
                if(c == '(' || c == ')' || c == '+' || c == '-' || c == '*' || c == '/' || c == '^')
                {
                    stack.Push(c);
                }
            }
            // While X is operator, check it against operator[TOP] to see if it has a higher or equal precedence.
            //     IF X HIGHER OR EQUAL PRECEDENCE, pop TOP and add TOP to output stack.
            //     ELSE, push X to operator stack. ---> no else needed??
            while (!StackEmpty(stack))
            {
                foreach(char c in infix)
                {
                    string top = Top(stack);
                    int precedenceOfTop = Precedence(top);
                    int precedenceOfCurrent = Precedence(c.ToString());

                    if(precedenceOfCurrent >= precedenceOfTop)
                    {
                        if (!StackEmpty(stack))
                        {
                            output += stack.Pop();
                        }
                    }
                }
            }

            return output;
        }

        public int Precedence(string symbol)
        {
            if (symbol == "(" || symbol == ")")
            {
                return 4;
            }
            if (symbol == "^")
            {
                return 3;
            }
            else if (symbol == "*" || symbol == "/")
            {
                return 2;
            }
            else if (symbol == "+" || symbol == "-")
            {
                return 1;
            }
            else
            {
                return (0);
            }
        }

//                    //Places all operators in the stack, in order
//            foreach(char c in infix)
//            {
//                if (c == '(' || c == ')' || c == '+' || c == '-' || c == '*' || c == '/' || c == '^')
//                {
//                    numOfOperators++;
//                    int currPrecedence = Precedence(c);

//                    //Separates operators out into 3 strings based on precedence
//                    switch (currPrecedence)
//                    {
//                        case 3:
//                            precedence3 += c;
//                            break;
//                        case 2:
//                            precedence2 += c;
//                            break;
//                        case 1:
//                            precedence1 += c;
//                            break;
//                    }
//}
//            }

//            //Places operators into a string based on highest precedence first
//            operators += precedence3 + precedence2 + precedence1;

//            //Pushes operators onto stack in order of precedence
//            foreach (char o in operators)
//            {
//                stack.Push(o);
//            }

//            foreach (char item in stack)
//            {
//                Console.WriteLine(item);
//            }
    }
}
