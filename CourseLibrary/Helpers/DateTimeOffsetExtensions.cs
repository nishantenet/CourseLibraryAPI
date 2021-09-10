using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CourseLibrary.Helpers
{
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentAge (this DateTimeOffset datetimeoffset)
        {
            var currentdate = DateTime.UtcNow;
            int age = currentdate.Year - datetimeoffset.Year;
            if(currentdate < datetimeoffset.AddYears(age))
            {
                age--;
            }
            return age;
        }
        public static int GetOneAdditional( this int AddOneMore)
        {
            int val = AddOneMore;
            return val++;
        }
    }
}
