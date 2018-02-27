using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.Assignments
{
    public class DateTimeAlgorithm
    {
        public static string timeConversion(string s)
        {
            string hours = s.Substring(0, 2);

            int sum = (int.Parse(hours) + 12);
            if (s.Contains("AM"))
            {
                hours = hours == "12" ? "00" : hours;
            }
            else if (s.Contains("PM"))
            {
                hours = hours == "12" ? "12" : sum.ToString();
            }

            s = s.Substring(2, s.Length - 4);

            return hours.ToString() + s;
        }
    }
}
