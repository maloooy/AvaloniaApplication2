using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication2.Models
{
    public class RomanNumberException : Exception
    {
        public RomanNumberException(string mess)
          : base(mess)
        {

        }
    }
}
