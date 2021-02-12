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
            string top = Top(stack);

            foreach (char c in infix)
            {
                //Print operands as they arrive
                if (Char.IsNumber(c) || Char.IsLetter(c))
                {
                    output += c;
                }
                //If the stack is empty or contains a left parenthesis on top, push the incoming operator onto the stack. 
                else if (top == "(" || StackEmpty(stack))
                {
                    stack.Push(c);
                }
                //If the incoming symbol is a right parenthesis, pop the stack and print the operators until you see a left parenthesis. Discard the pair of parentheses. 
                else if (c == ')')
                {
                    while(stack.Count > 0 && top != ")")
                    {
                        output += stack.Peek();
                        stack.Pop();
                    }
                }
                //If the incoming symbol has higher precedence than the top of the stack, push it on the stack. 
                else if (Precedence(c.ToString()) > Precedence(top))
                {
                    stack.Push(c);
                }
                //If the incoming symbol has equal precedence with the top of the stack, use association. If the association is left to right, pop and print the top of the stack and then push the incoming operator. If the association is right to left, push the incoming operator. 
                else if(Precedence(c.ToString()) == Precedence(top))
                {
                    output += stack.Peek();
                    stack.Pop();
                    stack.Push(c);
                }
                //If the incoming symbol has lower precedence than the symbol on the top of the stack, pop the stack and print the top operator. Then test the incoming operator against the new top of stack. 
                else if (Precedence(c.ToString()) < Precedence(top))
                {
                    output += stack.Peek();
                    stack.Pop();

                    if(Precedence(c.ToString()) < Precedence(top))
                    {
                        output += stack.Peek();
                        stack.Pop();
                    }
                }
            }

            Stack tempStack = new Stack();

            //At the end of the expression, pop and print all operators on the stack. (No parentheses should remain.)
            while(stack.Count > 0)
            {
                tempStack.Push(stack.Peek());
                stack.Pop();
            }

            //Reverses the order of the stack (so top is on bottom)
            while (tempStack.Count > 0)
            {
                output += tempStack.Peek();
                tempStack.Pop();
            }

            //Discard parentheses
            if (output.Contains("("))
            {
                int index = output.IndexOf("(");
                output = output.Remove(index, 1);
            }
            if (output.Contains(")"))
            {
                int index = output.IndexOf(")");
                output = output.Remove(index, 1);
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
