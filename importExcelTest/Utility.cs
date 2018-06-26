using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using PersianDate;
using System.Windows.Forms;
using WindowsFormsApplication1;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace negar
{
    enum errorImages { warning, error, info,watch,puls };

    public class ComboboxItem
    {
        public ComboboxItem(string name, long value)
        {
            Text = name; Value = value;
        }
        public string Text { get; set; }
        public long Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    class Utility
    {
        public List<string> getColumnsHeader()
        {
            List<string> header = new List<string>();
            header.Add("شناسه");
            header.Add("استرداد");
            header.Add("شماره قبض سپرده");
            header.Add("تاریخ");
            header.Add("واحد ثبتی");
            header.Add("نوع حساب");
            header.Add("مشخصات صاحب سپرده");
            header.Add("کد مشخصات سپرده");
            header.Add("واریزی");
            header.Add("کد بودجه");
            header.Add("کد شهر");
            header.Add("تاریخ حقیقی");
            return header;
        }
        public bool isNullorWhiteSpace(string text)
        {
            if (text == null) return true;

            for (int i = 0; i < text.Length; i++)
            {
                if (!Char.IsWhiteSpace(text[i])) return false;
            }
            return true;

        }

        private static bool IsWhiteSpaceLatin1(char c)
        {
            return c == ' ' || (c >= '\t' && c <= '\r') || c == '\u00a0' || c == '\u0085';
        }
        public List<Daftarcs> convertYekeQuery(List<Daftarcs> data)
        {
            foreach (var a in data)
            {
                a.DepositOwnerDetail = YeKe.ApplyCorrectYeKe(a.DepositOwnerDetail.ToString());
                a.PlaceName = YeKe.ApplyCorrectYeKe(YeKe.ApplyCorrectYeKe(a.PlaceName.ToString()));              
            }
            return data;            
        }
        public List<Daftarcs> convertToRealDate(List<Daftarcs> data)
        {
            foreach(var a in data)
            {
                a.RealDate =changeToRealDate(a.Date);
            }
            return data;
        }
       public bool isvalidDate(string date)
        {
            if(!date.All(char.IsDigit))
            { return false; }
            if (date.ToString().Length == 6)
            {
                try {
                    var realdate = changeToRealDate(date);
                    var dt = formatStringDate(realdate.ToString()).ToEn().ToFa();
                }
                catch (Exception) {
                    return false; }

                return true;
            }
            else
            {
                return false;
            }
             
        }
        public List<string> getReportColumnsHeader()
        {
            List<string> header = new List<string>();
            header.Add("کد بودجه");
            header.Add("مشخصات صاحب سپرده");
            header.Add("نوع حساب");
            header.Add("عنوان واحد ثبتی");
            header.Add("تاریخ");
            header.Add("کد مشخصات سپرده");
            header.Add("واریزی");
            header.Add("استرداد");
            header.Add("واریزی");

            return header;
        }
        public   StartEndMonthClass getStartEndofMonth(int year,long month)
        {
            int days = getMonthsDay(year, Convert.ToInt32(month));
            string endDate = year.ToString() + "/" + month + "/" + days.ToString();
            endDate = endDate.ToEn().ToFa("yyyyMMdd");
            string startDate = year.ToString() + "/" + month + "/" + "01";
            startDate = startDate.ToEn().ToFa("yyyyMMdd");

            StartEndMonthClass st = new StartEndMonthClass();
            st.startDate = Convert.ToInt64(startDate);
            st.endDate = Convert.ToInt64(endDate);
            return st;

        }
        public List<long> findDuplicateID(List<long> list)
        {

            var query = list.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();

            return query;
        }
        public string getMonthName(int month)
        {
            //sort monthes if u need
            try {
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
            catch(Exception)
            {
                throw;
            }

        }
        public int getMonthsDay(int year, int month)
        {

            var persianCal = new System.Globalization.PersianCalendar();
            int monthsDay = persianCal.GetDaysInMonth(year, month);

            return monthsDay;
        }
        public string getPrvMonthLastDay()
        {
            try
            {
               
                var date = DateTime.Now.AddMonths(-1).ToFa();
                int lastdayofMonth = getMonthsDay(date);
                var splittedDate = date.Split('/');
                string endOfPrvMonth = splittedDate[0] + splittedDate[1] + lastdayofMonth.ToString();

                isvalidDate(endOfPrvMonth);
                return endOfPrvMonth;
            }
            catch(Exception)
            {
                throw;
            }

        }
        public string getPrvMonthFirstDay()
        {
            try
            {

                var date = DateTime.Now.AddMonths(-1).ToFa();
                string firstdayofMonth = "01";
                var splittedDate = date.Split('/');
                string firstOfPRVMonth = splittedDate[0] + splittedDate[1] + firstdayofMonth.ToString();

                isvalidDate(firstOfPRVMonth);
                return firstOfPRVMonth;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public string formatStringDate(string unformattedDate)
        {
                try { 
                string year = unformattedDate.Substring(0, 4);
                string month = unformattedDate.Substring(4, 2);
                string day = unformattedDate.Substring(6, 2);
                string date = year + "/" + month + "/" + day;
                return date;
                }
                catch (Exception)
                {
                    throw;
                }
        }
        public int getMonthsDay(String farsiDate)
        {
            try {
                var words = farsiDate.Split('/');
                string year = words[0];
                string month = words[1];

                var persianCal = new System.Globalization.PersianCalendar();
                int monthsDay = persianCal.GetDaysInMonth(Convert.ToInt32(year), Convert.ToInt32(month));

                return monthsDay;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public long changeToRealDate(string handDate)
        {
            try {
                string dt = handDate.ToString();
                if (Convert.ToInt64(new string(dt.Take(2).ToArray())) < 50)
                {
                    string result = "14" + dt.PadLeft(6, '0');
                    return Convert.ToInt64(result);
                }
                else
                {
                    string result = "13" + dt.PadLeft(6, '0');
                    return Convert.ToInt64(result);
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
        public string convertString(string text)
        {
            string changed = YeKe.ApplyCorrectYeKe(text);
            return changed;
        }
   
        internal long idGenerator(long cityID, string date, long? billDetailCode)
        {
            string id = cityID.ToString() + date + billDetailCode.ToString();
            Int64 idr = Convert.ToInt64(id);
            return idr;
        }
    }
    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}
