using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.Assignments
{
    public partial class Assignments
    {
        #region
        /*
         The field of astronomy has been significantly advanced through the use of computer technology. 
         Algorithms can automatically survey digital images of the night sky, looking for new patterns.

        For this problem, you should write such an analysis program which counts the number of stars visible in an bitmap image. 
        An image consists of pixels, and each pixel is either black or white (represented by the characters # and -, respectively). 
        All black pixels are considered to be part of the sky, and each white pixel is considered to be part of a star. 
        White pixels that are adjacent vertically or horizontally are part of the same star.

        Input
        Each test case begins with a line containing a pair of integers 1 ≤ m,n ≤ 1001 ≤ m,n ≤ 100. 
        This is followed by mm lines, each of which contains exactly nn pixels. 
        Input contains at least one and at most 5050 test cases, and input ends at the end of file.

        Output
        For each case, display the case number followed by the number of stars that are visible in the corresponding image.
        Follow the format of the sample output.
             
             */
        #endregion
        //public static int CountingStars(char[][] image)
        //{


        //}

        #region
        /*
         * 
         * Given a rectangular matrix of characters, add a border of asterisks(*) to it.

            Example

            For

            picture = ["abc",
                       "ded"]
            the output should be

            addBorder(picture) = ["*****",
                                  "*abc*",
                                  "*ded*",
                                  "*****"]
                     */
        #endregion
        public static string[] AddBorder(string[] picture)
        {
            if (picture.Length == 0)
            {
                return null;
            }

            string[] result = new string[picture.Length + 2];

            int longest = 0;
            for (int i = 0; i < picture.Length; i++)
            {
                if (longest < picture[i].Length)
                {
                    longest = picture[i].Length;
                }
            }

            StringBuilder builder = new StringBuilder(longest + 2);
            for (int i = 0; i < longest + 2; i++)
            {
                builder.Append('*');
            }

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = i == 0 || i == result.Length - 1 ? builder.ToString() : '*' + picture[i - 1] + '*';
            }

            return result;
        }
    }
}
