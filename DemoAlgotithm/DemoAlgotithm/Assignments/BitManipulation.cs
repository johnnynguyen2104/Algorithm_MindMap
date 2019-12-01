using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.Assignments
{
    public static class BitManipulation
    {
        static int lonelyinteger(int[] a)
        {
            int result = a[0];
            for (int i = 0; i < a.Length - 1; i++)
            {
                result = result ^ a[i + 1];
            }

            return result;
        }
    }
}
