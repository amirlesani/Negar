
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace negar
{
    
    class ExcelGeneratorClass
    {
        private string fileName;
        private List<string> header;
        private IQueryable<DaftarTable> query;

       

        public ExcelGeneratorClass(IQueryable<DaftarTable> data ,string path,List<string> header)
        {

            string newFileName = path + ".xlsx";
            var q = data.OrderBy(o => o.PlaceName);
            //var t = from a in q select new { a.CodeBudget,a.DepositOwnerDetail,a.AccountType,a.PlaceName,a.BillDetailCode,a.DepositDetail,a.Deposit,a.Refund };
            makeReport(q.ToList(), newFileName, header);

            //var p = (from a in data select new { a.CodeBudget, a.DepositOwnerDetail });

            //List<ExcelReportOnFormat> excelReport = new List<ExcelReportOnFormat>();

            //string newFileName2 = path + ".xlsx";
            //makeReport(data.ToList(),newFileName2,header);



            //var q = from row in db.DaftarTables
            //        group row by true into r
            //        select new { min = r.Min(z => z.RealDate), max = r.Max(z => z.RealDate) };
        }
        public string ReplaceXMLEncodedCharacters(string input)
        {
            const string pattern = @"&#(x?)([A-Fa-f0-9]+);";
            MatchCollection matches = Regex.Matches(input, pattern);
            int offset = 0;
            foreach (Match match in matches)
            {
                int charCode = 0;
                if (string.IsNullOrEmpty(match.Groups[1].Value))
                    charCode = int.Parse(match.Groups[2].Value);
                else
                    charCode = int.Parse(match.Groups[2].Value, System.Globalization.NumberStyles.HexNumber);
                char character = (char)charCode;
                input = input.Remove(match.Index - offset, match.Length).Insert(match.Index - offset, character.ToString());
                offset += match.Length - 1;
            }
            return input;
        }

        private List<DaftarTable> correctToXmlChar(List<DaftarTable> source)
        {
            List<DaftarTable> q = new List<DaftarTable>();
            q = source;
            //foreach (var data in q)
            //{
            //    data.AccountType = XmlConvert.EncodeName(data.AccountType.ToString());
            //    data.DepositOwnerDetail = XmlConvert.EncodeName(data.DepositOwnerDetail);
            //    data.PlaceName = XmlConvert.EncodeName(data.PlaceName);
            //}
            return q;
        }
        private string makeReport(List<DaftarTable> source, string dest,List<string> header)
        {
            string result = "report finished";
            try
            {
               var data = correctToXmlChar(source);
                CreateExcelFile.CreateExcelDocument<DaftarTable>(data,dest,header,true);
                //checking file 
                // CreateExcelFile.validation(dest);

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
      
    }
}