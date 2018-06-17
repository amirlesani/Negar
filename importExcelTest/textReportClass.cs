using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace negar
{
    public class  textReportClass
    {
        IQueryable<DaftarTable> data;
        public textReportClass(IQueryable<DaftarTable> data,string path)
        {
            this.data = data;
            WriteCharacters(data,path);
        }
        static void WriteCharacters(IQueryable<DaftarTable> data, string path)
        {
            //  StringBuilder objBuilder = new StringBuilder();
            try
            {
                var orderedData = data.OrderBy(a=>a.PlaceName);
                using (StreamWriter writer = File.CreateText(path))
                {
                    foreach (var a in orderedData)
                    {
                        // string format = "  {0,15}   {1,-15}   {2,-15}   {3,-15}   {4,-15}  {5,-15}  {6,-15}   ";
                        string s = "\t";
                        //  string line = String.Format(format,a.CodeBudget, a.AccountType,a.BillDetailCode,a.Date,a.BillDetailCode,a.Deposit,a.Refund)  ;
                        //  line = line +"\t"+ a.DepositOwnerDetail.ToString();
                        //   + s + String.Format(format,a.Date )+ s +String.Format(format, a.DepositDetail) + s + String.Format(format, a.Deposit )+ s +String.Format(format, a.Refund);
                        string line = a.CodeBudget + s + a.DepositOwnerDetail + s + a.AccountType + s + a.PlaceName + s + a.BillDetailCode + s + a.Date + s + a.DepositDetail + s + a.Deposit + s + a.Refund;

                        writer.WriteLine(line);
                        writer.Write("\n");

                    }
                    //   writer.WriteLine(objBuilder.ToString());

                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                
            }

          }
        }
}
