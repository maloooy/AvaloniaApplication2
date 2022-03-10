using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using AvaloniaApplication2.Models;

namespace AvaloniaApplication2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    { 
        string number2;
        string op = " ";
        private RomanNumberExtend res;
        private RomanNumberExtend value2;
        public MainWindowViewModel()
        {
            AddNum = ReactiveCommand.Create<string,string>(AddNumTo);
            ExecuteOperationCommand = ReactiveCommand.Create<string>(ExecuteOperation);
        }
        public string ShowValue
        {
            set
            {
                this.RaiseAndSetIfChanged(ref number2, value);
            }
            get
            {
                return number2;
            }
        }
        public ReactiveCommand<string,string> AddNum { get; }
        public ReactiveCommand<string,Unit> ExecuteOperationCommand { get; }

        private string AddNumTo(string str)
        {
            if (op == "n")
            {
                ShowValue = str;
                op = " ";
            }
            else
            {
                ShowValue += str;
            }
            return ShowValue;
        }
        private void ExecuteOperation(string operation) {
            if (RomanNumberExtend.ToInteger(number2) > 0)
                value2 = new RomanNumberExtend(number2);
            RomanNumber tmp;
            try
            {
                switch (op[0])
                {
                    case '+':
                        {
                            tmp = res + value2;
                            res = new RomanNumberExtend(tmp.ToString());
                            break;
                        }
                    case '*':
                        {
                            tmp = res * value2;
                            res = new RomanNumberExtend(tmp.ToString());
                            break;
                        }
                    case '/':
                        {
                            tmp = res / value2;
                            res = new RomanNumberExtend(tmp.ToString());
                            break;
                        }
                    case '-':
                        {
                            tmp = res - value2;
                            res = new RomanNumberExtend(tmp.ToString());
                            break;
                        }
                    case ' ':
                        {
                            if (RomanNumberExtend.ToInteger(number2) > 0)
                                res = new RomanNumberExtend(number2);
                            break;
                        }
                    case 'n':
                        {
                            if (RomanNumberExtend.ToInteger(number2) > 0)
                                res = new RomanNumberExtend(number2);
                            break;
                        }
                    default:
                        break;
                }
                if (operation == "=")
                {
                    if (res != null)
                        ShowValue = res.ToString();
                    op = "n";
                    res = null;
                }
                else
                {
                    op = operation;
                    ShowValue = "";
                }
            }
            catch (RomanNumberException ex)
            {
                ShowValue = $"{ex.Message}";
            }
        }
    }
}