using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace negar
{
    interface persianDateFunc
    {
        string getMonthName(int month);
        string extractDate(string unformattedDate);
    }
    public class FarsiDateUtil : persianDateFunc
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string MonthName { get; set; }
        public FarsiDateUtil(string unformattedDate)
        {
            extractDate(unformattedDate);
        }
        public string getMonthName(int month)
        {

            try
            {
                Dictionary<string, int> monthDictionary =
                new Dictionary<string, int>();
                monthDictionary.Add("فروردین", 1); monthDictionary.Add("اردیبهشت", 2);
                monthDictionary.Add("خرداد", 3); monthDictionary.Add("تیر", 4);
                monthDictionary.Add("مرداد", 5); monthDictionary.Add("شهریور", 6);
                monthDictionary.Add("مهر", 7); monthDictionary.Add("آبان", 8);
                monthDictionary.Add("آذر", 9); monthDictionary.Add("دی", 10);
                monthDictionary.Add("بهمن", 11); monthDictionary.Add("اسفند", 12);



                foreach (var a in monthDictionary)
                {
                    if (a.Value == month)
                    {
                        return a.Key;
                    }
                }
                return "";
            }
            catch (Exception)
            {
                throw;
            }

        }
        public string extractDate(string unformattedDate)
        {
            try
            {
                string year = unformattedDate.Substring(0, 4);
                this.Year = year;
                string month = unformattedDate.Substring(4, 2);
                this.Month = month;
                string day = unformattedDate.Substring(6, 2);
                this.Day = day;
                string date = year + "/" + month + "/" + day;
                this.MonthName = getMonthName(Convert.ToInt32(this.Month));
                return date;
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
   
}
