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
        public static int maximumNonAdjacentCellsSum(int[,] matrix)
        {
            int row = matrix.GetLength(0)
                , column = matrix.GetLength(1)
                , max = int.MinValue;
            List<string> array = new List<string>();     

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (matrix[i,j] > max)
                    {
                        array.Insert(0, $"{i}.{j}");
                        max = matrix[i, j];
                    }
                    else
                    {
                        array.Add($"{i}.{j}");
                    }
                }
            }

            int c, d, c1, d1;
            string[] splited , splited1;
            array.Sort(delegate (string x, string y) {

                splited = x.Split('.');
                d = int.Parse(splited[0]);
                c = int.Parse(splited[1]);

                splited1 = y.Split('.');
                d1 = int.Parse(splited1[0]);
                c1 = int.Parse(splited1[1]);


                return (matrix[d1, c1].CompareTo(matrix[d, c]));
            });

            int result = 0;
            //use max + 1 as a marker
            max++;
            for (int i = 0; i < array.Count; i++)
            {
                splited = array[i].Split('.');
                d = int.Parse(splited[0]);
                c = int.Parse(splited[1]);
                //top
                if (c - 1 >= 0)
                {
                    if (matrix[d, c- 1] == max)
                    {
                        continue;
                    }
                }

                //down
                if (c + 1 <= column - 1)
                {
                    if (matrix[d, c + 1] == max)
                    {
                        continue;
                    }
                }
                //Left
                if (d - 1 >= 0)
                {
                    if (matrix[d - 1, c] == max)
                    {
                        continue;
                    }
                }
                //Right
                if (d + 1 <= row - 1)
                {
                    if (matrix[d + 1, c] == max)
                    {
                        continue;
                    }
                }

                result += matrix[d, c];
                matrix[d, c] = max;
            }

            return result;
        }


        public static int maximumNonAdjacentCellsSum(int[][] matrix)
        {
            int row = matrix.GetLength(0)
               , column = matrix[0].Length
               , max = int.MinValue;
            List<string> array = new List<string>();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (matrix[i][j] > max)
                    {
                        array.Insert(0, $"{i}.{j}");
                        max = matrix[i][j];
                    }
                    else
                    {
                        array.Add($"{i}.{j}");
                    }
                }
            }

            int c, d, c1, d1;
            string[] splited, splited1;
            array.Sort(delegate (string x, string y) {

                splited = x.Split('.');
                d = int.Parse(splited[0]);
                c = int.Parse(splited[1]);

                splited1 = y.Split('.');
                d1 = int.Parse(splited1[0]);
                c1 = int.Parse(splited1[1]);


                return (matrix[d1][c1].CompareTo(matrix[d][c]));
            });

            int result = 0;
            //use max + 1 as a marker
            max++;
            for (int i = 0; i < array.Count; i++)
            {
                splited = array[i].Split('.');
                d = int.Parse(splited[0]);
                c = int.Parse(splited[1]);
                //top
                if (c - 1 >= 0)
                {
                    if (matrix[d][c - 1] == max)
                    {
                        continue;
                    }
                }

                //down
                if (c + 1 <= column - 1)
                {
                    if (matrix[d][c + 1] == max)
                    {
                        continue;
                    }
                }
                //Left
                if (d - 1 >= 0)
                {
                    if (matrix[d - 1][c] == max)
                    {
                        continue;
                    }
                }
                //Right
                if (d + 1 <= row - 1)
                {
                    if (matrix[d + 1][c] == max)
                    {
                        continue;
                    }
                }

                result += matrix[d][c];
                matrix[d][c] = max;
            }

            return result;
        }


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
