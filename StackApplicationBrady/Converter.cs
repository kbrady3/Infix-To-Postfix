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
            string output = "";
            Console.WriteLine(infix);
            Stack stack = new Stack();

            foreach (char c in infix)
            {
                Console.WriteLine(c);
                if (Char.IsNumber(c) || Char.IsLetter(c))
                {
                    output += c;
                }

                if (IsOperator(c) && StackEmpty(stack))
                {
                    stack.Push(c);
                }
                else if (IsOperator(c) && !StackEmpty(stack))
                {
                    string top = Top(stack);
                    int precedenceOfTop = Precedence(top);
                    int precedenceOfCurrent = Precedence(c.ToString());

                    if (precedenceOfCurrent > precedenceOfTop)
                    {
                        stack.Push(c);
                    }
     
                    if (precedenceOfCurrent <= precedenceOfTop)
                    {
                        if (stack.Count > 0)
                        {
                            while(top != "(" && top != ")")
                            {
                                if(stack.Count > 0)
                                {
                                    stack.Pop();
                                }
                            }
                        }

                        if (c == '(')
                        {
                            stack.Push(c);
                        }
                        else if (c == ')')
                        {
                            while (top != "(")
                            {
                                stack.Pop();
                            }
                        }
                    }
                }
            }

            while (!StackEmpty(stack))
            {
                output += Top(stack);
            }

            return output;
        }

        public bool IsOperator(char c)
        {
            if(c == '+' || c == '-' || c == '*' || c == '/' || c == '^')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool StackEmpty(Stack s) { 
            if (s.Count == 0) { return true; } 
            else { return false; } 
        }

        public string Top(Stack s) { 
            if (s.Count != 0) { return s.Peek().ToString(); } 
            else { return null; } 
        }

        public int Precedence(string symbol)
        {
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
    }
}
