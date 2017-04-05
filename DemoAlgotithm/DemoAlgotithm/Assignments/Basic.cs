using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.Assignments
{
    public partial class Assignments
    {
        public static void FizzBuzz(int endpoint)
        {
            StringBuilder builder = new StringBuilder(8);
            for (int i = 0; i < endpoint; i++)
            {
                builder.Append(i % 3 == 0 ? "Fizz" : "");
                builder.Append(i % 5 == 0 ? "Buzz" : "");
                builder.Append(builder.Length == 0 ? i.ToString() : "");
            }
        }
    }
}
