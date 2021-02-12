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
            Stack stack = new Stack();

            foreach (char c in infix)
            {
                if (Char.IsNumber(c) || Char.IsLetter(c))
                {
                    output += c;
                }
                //If the character is an operator and operator's stack is empty, push operator into operators' stack.
                if (IsOperator(c) && StackEmpty(stack))
                {
                    stack.Push(c);
                }
                if (IsOperator(c) && !StackEmpty(stack))
                {
                    string top = Top(stack);
                    int precedenceOfTop = Precedence(top);
                    int precedenceOfCurrent = Precedence(c.ToString());

                    //If the precedence of scanned operator is greater than the top most operator of operator's stack, push this operator into operand's stack.
                    if (precedenceOfCurrent > precedenceOfTop)
                    {
                        stack.Push(c);
                    }
                    //If the precedence of scanned operator is less than or equal to the top most operator of operator's stack, pop the operators from operand's stack until we find a lower precedence operator than the scanned character. Never pop out ( '(' ) or( ')' ) whatever may be the precedence level of scanned character.
                    if (precedenceOfCurrent <= precedenceOfTop)
                    {
                        if (stack.Count > 0)
                        {
                            while(top != "(" && top != ")" && precedenceOfCurrent > precedenceOfTop)
                            {
                                stack.Pop();
                            }
                        }
                        //If the character is opening round bracket( '(' ), push it into operator's stack.
                        if (c == '(')
                        {
                            stack.Push(c);
                        }
                        //If the character is closing round bracket ( ')' ), pop out operators from operator's stack until we find an opening bracket ('(' ).
                        else if (c == ')')
                        {
                            while (top != "(")
                            {
                                stack.Pop();
                            }
                        }
                    }

                    //Now pop out all the remaining operators from the operator's stack and push into output stack.
                    while (!StackEmpty(stack))
                    {
                        output += Top(stack);
                    }
                }
            }

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
            //if (symbol == "(" || symbol == ")")
            //{
            //    return 4;
            //}
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
