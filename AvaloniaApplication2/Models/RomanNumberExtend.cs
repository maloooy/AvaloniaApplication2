using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication2.Models
{
    public class RomanNumberExtend : RomanNumber
    {
        public static ushort ToInteger(string number)
        {


            number = new string(number.Reverse().ToArray());
            ushort to_integer = 0;
            for (int i = 0; i < number.Length; i++)
            {
                switch (number[i])
                {
                    case 'M':
                        to_integer += 1000;
                        break;
                    case 'D':
                        to_integer += 500;
                        break;
                    case 'C':
                        to_integer += 100;
                        if (i > 0)
                        {
                            if (number[i - 1] == 'M' || number[i - 1] == 'D')
                            {
                                to_integer -= 200;
                            }
                        }
                        break;
                    case 'L':
                        to_integer += 50;
                        break;
                    case 'X':
                        to_integer += 10;
                        if (i > 0)
                        {
                            if (number[i - 1] == 'C' || number[i - 1] == 'L')
                            {
                                to_integer -= 20;
                            }
                        }
                        break;
                    case 'V':
                        to_integer += 5;
                        break;
                    case 'I':
                        to_integer += 1;
                        if (i > 0)
                        {
                            if (number[i - 1] == 'X' || number[i - 1] == 'V')
                            {
                                to_integer -= 2;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            return to_integer;
        }
        public RomanNumberExtend(string num) : base(ToInteger(num)) { }
    }
}
