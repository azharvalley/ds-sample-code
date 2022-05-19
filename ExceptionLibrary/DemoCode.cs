using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLibrary
{
    public class DemoCode
    {
        public int GrandParentMethod(int position)
        {
            return ParentMethod(position);
        }
        public int ParentMethod(int position)
        {
            return GetNumber(position);
        }
        public int GetNumber(int position)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };
            return numbers[position];
        }
    }
}
