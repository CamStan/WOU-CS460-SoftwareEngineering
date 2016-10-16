using System;

namespace HW3
{
    /// <summary>
    /// Command line postfix calculator.
    /// 
    /// This code is referenced from a similar Java class written by Scot Morse.
    /// Modifed by Cameron Stanavige
    /// </summary>
    class Calculator
    {
        /**
         * Data structure to hold the operands for the postfix calculation.
         */
        private IStackADT stack = new LinkedStack();

        /// <summary>
        /// Property to get the stack containing the calculation operands.
        /// </summary>
        private IStackADT Stack
        {
            get { return stack; }
        }

        /// <summary>
        /// Entry point method. 
        /// </summary>
        /// <param name="args">The command line arguments. None needed for this program.</param>
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            bool calculateAgain = true;
            Console.Write("Postfix Calculator.\nRecognized operators: + - * /");
            while (calculateAgain)
            {
                calculateAgain = calc.Calculate();
            }
            Console.Write("Thank you for feeding me. Goodbye.");
        }

        /// <summary>
        /// Get input string from user and perform calculation, returning true
        /// when finished. If the user wishes to quit this method returns false.
        /// </summary>
        /// <returns>True if a calculation succeeded, false if the usere wishes
        /// to quit.</returns>
        private bool Calculate()
        {
            Console.Write("\nPlease enter q to quit\n\n> ");
            string input, output = "";

            input = Console.ReadLine();
            // See if user wishes to quit.
            if (input.Trim().ToLower().StartsWith("q"))
            {
                return false;
            }
            // Go ahead with calculation
            try
            {
                output = EvaluatePostFixInput(input);
            }
            catch (ArgumentException ex)
            {
                output = ex.Message;
            }
            Console.Write("\n\t>>> " + input + " = " + output);
            return true;
        }

        /// <summary>
        /// Evaluate an arithmetic expression written in postfix form.
        /// </summary>
        /// <param name="input">Postfix mathematical expression input
        /// by the user as a string.</param>
        /// <returns>Answer as a string.</returns>
        private string EvaluatePostFixInput(string input)
        {
            if (input == null || input.Equals(""))
                throw new ArgumentException("Null or the empty string are not valid postfix expressions");
            Stack.Clear(); // Clear the stack before doing a new calculation.
            int stackCount = 0; // Track the number of operands in the stack.

            double a, b, c, x; // Temporary variables for two operands, answer, and TryParse

            string[] variables = input.Trim().Split(' ');
            foreach (string v in variables)
            {
                // if it's a number, push it on the stack
                if (Double.TryParse(v, out x))
                {
                    Stack.Push((x));
                    stackCount++;
                }
                else // Must be an operator or some other character/word.
                {
                    if (v.Length > 1)
                        throw new ArgumentException("Input Error: " + v + " is not an allowed number or operator");
                    // may be an operator, so pop two values off stack and perform operation
                    if (Stack.IsEmpty())
                        throw new ArgumentException("Improper input format. Stack became empty when expecting second operand.");
                    b = (double)Stack.Pop();
                    if (Stack.IsEmpty())
                        throw new ArgumentException("Improper input format. Stack became empty when expecting first operand.");
                    a = (double)Stack.Pop();
                    // Send values to another method to perform operation.
                    c = Evaluate(a, b, v, ref stackCount);
                    // Push answer from operation back onto the stack.
                    Stack.Push(c);
                }
            } // end foreach
            // Bug fix: If only one thing left on stack, that is the answer, otherwise the user input the wrong number of operators
            if (stackCount > 1)
                throw new ArgumentException("Input Error: Improper operand to operator ratio.");
            return Stack.Pop().ToString();
        }

        /// <summary>
        /// Perform arithmetic.
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="v">Operator</param>
        /// <param name="stackCount">Number of items on stack, passed by reference.</param>
        /// <returns>The answer</returns>
        private double Evaluate(double a, double b, string v, ref int stackCount)
        {
            double c = 0.0;
            if (v.Equals("+"))
                c = (a + b);
            else if (v.Equals("-"))
                c = (a - b);
            else if (v.Equals("*"))
                c = (a * b);
            else if (v.Equals("/"))
            {
                try
                {
                    c = (a / b);
                    if (Double.IsNegativeInfinity(c) || Double.IsPositiveInfinity(c))
                        throw new ArgumentException("Can't divide by zero.");
                }
                catch (ArithmeticException ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
            else
                throw new ArgumentException("Improper operator: " + v + ", is not one of +, -, *, or /");

            stackCount--; // operation successful, so will have one less item on stack
            return c;
        }
    } // end class Calculator
}
