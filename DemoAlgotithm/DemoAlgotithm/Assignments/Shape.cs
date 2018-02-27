using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.Assignments
{
    public partial class Assignments
    {
        public static int ShapeArea(int n)
        {
            return (n*n) + ((n - 1)*(n - 1));
        }

        /// <summary>
        /// Show the triangles
        /// </summary>
        /// <param name="n"></param>
        public static void StairCase(int n)
        {
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = n - 1; j >= 0; j--)
                    {
                        if (j > i)
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("#");
                        }
                    }
                    Console.WriteLine();

                }
            }
        }
    }
}
