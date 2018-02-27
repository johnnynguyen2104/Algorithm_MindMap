using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DemoAlgotithm.Assignments
{
    public partial class Assignments
    {

        static int DiagonalDifference(int[][] a)
        {
            int row = a.GetLength(0), column = a.GetLength(0);
            int left = 0, right = 0;
            for (int i = 0; i < row; i++)
            {
                left += a[i][i];
                right += a[i][column - 1];

                column--;
            }

            return left - right;
        }

        public static int MatrixElementsSum(int[][] matrix)
        {
            int rows = matrix.GetLength(0), 
                columns = matrix[0].Length, 
                result = 0;

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[j][i] == 0)
                    {
                        break;
                    }
                    result += matrix[j][i];
                }
                
            }
            return result;
        }

    }

}
