using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Calculus
{
    internal class input
    {
        public bool Matrix_input_check(ref string[] Args,ref int m)
        {
            if (Args.Length != m) return false;
            if (Args.Length == 1 && Args[0] == "") return false;
            else return true;
        }
    }
}
