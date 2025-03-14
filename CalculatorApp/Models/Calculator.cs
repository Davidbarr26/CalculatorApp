using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Models
{
    public enum CurrentState
    {
        FirstNumber,
        SecondNumber
    }

    public class Calculator
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string MathOperator { get; set; }
        public string Result { get; set; }
        public string Equation { get; set; }
        public CurrentState State { get; set; }

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
