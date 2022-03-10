using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication2.Models
{
    public class RomanNumber : ICloneable, IComparable
    {
        private ushort number;
        private static int[] val = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private static string[] romanian = new string[]
            { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        public RomanNumber(ushort n)
        {
            if (n <= 0) throw new RomanNumberException($"number {n} is less or equal to 0");
            else this.number = n;
        }
        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            int num = n1.number + n2.number;
            if (num <= 0) throw new RomanNumberException("failed to add numbers");
            else
            {
                RomanNumber result = new((ushort)num);
                return result;
            }
        }
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            int num = n1.number - n2.number;
            if (num <= 0) throw new RomanNumberException("subtraction result is less or equal to 0");
            else
            {
                RomanNumber result = new((ushort)num);
                return result;
            }
        }
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            int num = n1.number * n2.number;
            if (num <= 0) throw new RomanNumberException("failed to multiply numbers");
            else
            {
                RomanNumber result = new((ushort)num);
                return result;
            }
        }
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {

            if (n2.number == 0) throw new RomanNumberException("division error");
            else
            {
                int num = n1.number / n2.number;
                if (num == 0) throw new RomanNumberException("division error");
                else
                {
                    RomanNumber result = new((ushort)num);
                    return result;
                }
            }
        }
        public override string ToString()
        {
            int temp = number;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 13; i++)
            {
                while (temp >= val[i])
                {
                    temp -= (ushort)val[i];
                    result.Append(romanian[i]);
                }
            }
            if (result.ToString() == "")
                throw new RomanNumberException("conversion to roman numerals is not possible");
            else
                return result.ToString();

        }

        public object Clone()
        {
            return new RomanNumber(number);
        }

        public int CompareTo(object? obj)
        {
            if (obj is RomanNumber roman)
                return number.CompareTo(roman.number);
            else
                throw new RomanNumberException("object is not a RomanNumber");
        }

    }

}