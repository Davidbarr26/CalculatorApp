using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CalculatorApp.Models;

namespace CalculatorApp.ViewModels
{
    public partial class CalculatorPageViewModel : ObservableObject
    {
        private readonly Calculator _calculator;

        // Constructor to initialize the ViewModel
        public CalculatorPageViewModel()
        {
            _calculator = new Calculator();
        }

        // Observable properties for data binding
        [ObservableProperty]
        private string _numbersLabel = "0";

        [ObservableProperty]
        private string _equationLabel = string.Empty;

        // Command to handle number and decimal button clicks
        [RelayCommand]
        private void SelectNumber(string number)
        {
            if (_calculator.State == CurrentState.FirstNumber)
            {
                if (_calculator.FirstNumber == 0 && number != ".")
                {
                    NumbersLabel = number;
                    _calculator.FirstNumber = double.Parse(number);
                }
                else
                {
                    NumbersLabel += number;
                    _calculator.FirstNumber = double.Parse(NumbersLabel);
                }
            }
            else
            {
                if (_calculator.SecondNumber == 0 && number != ".")
                {
                    NumbersLabel = number;
                    _calculator.SecondNumber = double.Parse(number);
                }
                else
                {
                    NumbersLabel += number;
                    _calculator.SecondNumber = double.Parse(NumbersLabel);
                }
            }
        }

        // Command to handle math operator button clicks
        [RelayCommand]
        private void SelectMathOperator(string mathOperator)
        {
            if (_calculator.State == CurrentState.FirstNumber)
            {
                _calculator.MathOperator = mathOperator;
                _calculator.State = CurrentState.SecondNumber;
                EquationLabel = $"{_calculator.FirstNumber} {_calculator.MathOperator}";
            }
            else
            {
                Calculate();
                _calculator.MathOperator = mathOperator;
                EquationLabel = $"{_calculator.Result} {_calculator.MathOperator}";
            }
        }

        // Command to handle percentage button click
        [RelayCommand]
        private void SelectPercentage()
        {
            if (_calculator.State == CurrentState.FirstNumber)
            {
                _calculator.FirstNumber = MathUtil.Percentage(_calculator.FirstNumber);
                NumbersLabel = _calculator.FirstNumber.ToString();
                EquationLabel = $"{_calculator.FirstNumber} x 0.01 =";
            }
            else
            {
                _calculator.SecondNumber = MathUtil.Percentage(_calculator.SecondNumber);
                NumbersLabel = _calculator.SecondNumber.ToString();
                EquationLabel = $"{_calculator.FirstNumber} {_calculator.MathOperator} {_calculator.SecondNumber} x 0.01 =";
            }
        }

        // Command to clear all entries
        [RelayCommand]
        private void Clear()
        {
            _calculator.FirstNumber = 0;
            _calculator.SecondNumber = 0;
            _calculator.MathOperator = string.Empty;
            _calculator.Result = "0";
            _calculator.State = CurrentState.FirstNumber;
            NumbersLabel = "0";
            EquationLabel = string.Empty;
        }

        // Command to clear the current entry
        [RelayCommand]
        private void ClearEntry()
        {
            if (_calculator.State == CurrentState.FirstNumber)
            {
                _calculator.FirstNumber = 0;
                NumbersLabel = "0";
            }
            else
            {
                _calculator.SecondNumber = 0;
                NumbersLabel = "0";
            }
        }

        // Command to negate the current number
        [RelayCommand]
        private void Negate()
        {
            if (_calculator.State == CurrentState.FirstNumber)
            {
                _calculator.FirstNumber = -_calculator.FirstNumber;
                NumbersLabel = _calculator.FirstNumber.ToString();
            }
            else
            {
                _calculator.SecondNumber = -_calculator.SecondNumber;
                NumbersLabel = _calculator.SecondNumber.ToString();
            }
        }

        // Command to calculate the result
        [RelayCommand]
        private void Calculate()
        {
            try
            {
                double result = _calculator.MathOperator switch
                {
                    "+" => MathUtil.Add(_calculator.FirstNumber, _calculator.SecondNumber),
                    "-" => MathUtil.Subtract(_calculator.FirstNumber, _calculator.SecondNumber),
                    "×" => MathUtil.Multiply(_calculator.FirstNumber, _calculator.SecondNumber),
                    "÷" => MathUtil.Divide(_calculator.FirstNumber, _calculator.SecondNumber),
                    _ => _calculator.FirstNumber
                };

                _calculator.Result = result.ToString();
                NumbersLabel = _calculator.Result;
                EquationLabel = $"{_calculator.FirstNumber} {_calculator.MathOperator} {_calculator.SecondNumber} =";
                _calculator.FirstNumber = result;
                _calculator.State = CurrentState.FirstNumber;
            }
            catch (DivideByZeroException)
            {
                NumbersLabel = "Error";
            }
        }
    }
}
