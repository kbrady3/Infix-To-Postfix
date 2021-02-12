using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StackApplicationBrady
{
    public class Converter
    {
        public string Convert(string infix)
        {
            Stack stack = new Stack();

            string output = "";

            foreach (char c in infix)
            {
                if (Char.IsNumber(c))
                {
                    output += c;
                }
                else if (Char.IsLetter(c))
                {
                    output += c;
                }
                else if (c == '(' || c == ')' || c == '+' || c == '-' || c == '*' || c == '/' || c == '^')
                {
                    if(stack.Count > 0)
                    {
                        bool allElementsSorted = false;

             while (!stackIsEmpty() AND isOperator(top_of_stack) AND precedence(top_of_stack) >= precedence(item)) 

                        while (!StackIsEmpty(stack))
                        {
                            int topOfStackPrecedence = 0;

                            if (stack.Count > 0)
                            {
                                topOfStackPrecedence = Precedence(stack.Peek().ToString()); //Gets the precedence of the top item in stack
                            }
                            else
                            {
                                break;
                            }
                            
                            int currPrecedence = Precedence(c.ToString()); //Gets precedence of current item
                            if (topOfStackPrecedence < currPrecedence)
                            {
                                stack.Push(c); //Push current symbol
                            }
                            else
                            {
                                stack.Pop();
                                stack.Push(c);
                            }

                            if (c == ')')
                            {
                                string top = "";
                                
                                if(stack.Count > 0)
                                {
                                    top = stack.Peek().ToString();
                                }
                                else
                                {
                                    break;
                                }
                                
                                while(top != "(")
                                {
                                    
                                    output += top; //Write operators to output
                                    stack.Pop(); //Then pop them from the stack
                                }

                                stack.Pop(); //Pops the left parenthesis
                            }

                            if(stack.Count <= 0)
                            {
                                allElementsSorted = true;
                            }
                        }
                    }
                    else
                    {
                        stack.Push(c); //Pushes element onto stack if stack is null
                    }
                }
            }

            return output;
        }

        public bool StackIsEmpty(Stack s)
        {
            try
            {
                s.Peek();
                return false;
            }
            catch //If s.Peek() throws a stack empty exception
            {
                return true;
            }
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
