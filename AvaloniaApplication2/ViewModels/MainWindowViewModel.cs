using AvaloniaApplication2.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace AvaloniaApplication2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private double _firstValue;
        private double _secondValue;
        private string qwe;
        private int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private string[] numerals = new string[]  { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        private StringBuilder result = new StringBuilder();
        private Operation _operation = Operation.Add;
        public static string NumberToRoman(double number)
        {
            if (number < 0 || number > 3999)
                throw new ArgumentException("Value must be in the range 0 - 3,999.");

            if (number == 0) return "0";

            int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] numerals = new string[]
            { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };


            StringBuilder result = new StringBuilder();


            for (int i = 0; i < 13; i++)
            {
                while (number >= values[i])
                {
                    number -= values[i];
                    result.Append(numerals[i]);
                }
            }

            return result.ToString();
        }
        

        public double ShownValue
        {
            get => _secondValue;
            set => this.RaiseAndSetIfChanged(ref _secondValue, value);
        }
        public string NumberToRoam
        {
            get => qwe;
            set => this.RaiseAndSetIfChanged(ref qwe, value);
        }
        public ReactiveCommand<int, Unit> AddNumberCommand { get; }
        public ReactiveCommand<int, Unit> TransferToRim { get; }
        public ReactiveCommand<Unit, Unit> RemoveLastNumberCommand { get; }
        public ReactiveCommand<Operation, Unit> ExecuteOperationCommand { get; }

        public MainWindowViewModel()
        {
            AddNumberCommand = ReactiveCommand.Create<int>(AddNumber);
            ExecuteOperationCommand = ReactiveCommand.Create<Operation>(ExecuteOperation);
            RemoveLastNumberCommand = ReactiveCommand.Create(RemoveLastNumber);
            RxApp.DefaultExceptionHandler = Observer.Create<Exception>(
                    ex => Console.Write("next"),
                    ex => Console.Write("Unhandled rxui error"));

        }

        private void AddNumber(int value)
        {
            
            ShownValue = ShownValue + value;
            NumberToRoam = NumberToRoman(ShownValue);
        }
        public void ClearScreen()
        {
            ShownValue = 0;
            NumberToRoam = "0";
            _operation = Operation.Add;
            _firstValue = 0;
        }
        public void Exit()
        {
            Environment.Exit(0);
        }
        public void RemoveLastNumber()
        {
            ShownValue = (int)ShownValue / 10;
            NumberToRoam = NumberToRoman(ShownValue);
        }
        private void ExecuteOperation(Operation operation)
        {
            switch (_operation)
            {
                case Operation.Add:
                    {
                        _firstValue += _secondValue;
                        ShownValue = 0;
                        break;
                    }
                case Operation.Subtract:
                    {
                        _firstValue -= _secondValue;
                        ShownValue = 0;
                        break;
                    }
                case Operation.Multiply:
                    {
                        _firstValue *= _secondValue;
                        ShownValue = 0;
                        break;
                    }
                case Operation.Divide:
                    {
                        _firstValue /= _secondValue;
                        ShownValue = 0;
                        break;
                    }
            }

            if (operation == Operation.Result)
            {
                ShownValue = _firstValue;
                NumberToRoam = NumberToRoman(_firstValue);
                _operation = Operation.Add;
                _firstValue = 0;
            }
            else
            {
                _operation = operation;
            }
        }

    }


}
