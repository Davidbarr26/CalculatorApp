using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Models
{
    // Enum to track the current state of the calculator
    public enum CurrentState
    {
        FirstNumber,
        SecondNumber
    }

    public class Calculator
    {
        // Properties to hold the calculator state
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string MathOperator { get; set; }
        public string Result { get; set; }
        public string Equation { get; set; }
        public CurrentState State { get; set; }

        // Constructor to initialize the calculator state
        public Calculator()
        {
            FirstNumber = 0;
            SecondNumber = 0;
            MathOperator = string.Empty;
            Result = "0";
            Equation = string.Empty;
            State = CurrentState.FirstNumber;
        }
    }
}

