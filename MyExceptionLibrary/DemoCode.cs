using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExceptionLibrary
{
    public class DemoCode
    {
        public int GrandParentMethod(int position)
        {
            int output = 0;
            Console.WriteLine("Open Database connection");
            try
            {
                output = ParentMethod(position);
            }
            //catch (IndexOutOfRangeException ex)
            //{
            //    throw;
            //}
            catch (Exception ex)
            {
                // Log the exception in DataBase
                throw new ArgumentException($"{ex.Message} {ex.GetType()} You passed invalid data", ex);
            }
            finally
            {
                Console.WriteLine("Close Database connection");
            }
            return output;            
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
