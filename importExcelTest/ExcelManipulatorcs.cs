using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToExcel;
using System.Diagnostics;
using LinqToExcel.Query;
using System.Windows.Forms;
using negar;

namespace WindowsFormsApplication1
{
    class ExcelManipulatorcs
    {
        public ExcelManipulatorcs()
        {
            
        }
        public IEnumerable<string> getColumnsName(string sheetName,ExcelQueryFactory excelFile)
        {
            try {
                var colNames = excelFile
                    .GetColumnNames(sheetName, "A2:I2")
                    .ToList();
                return colNames;
            }
            catch(Exception)
            { throw; }
            
        }
        public IEnumerable<string> getSheetsName(string filePath)
        {
            string patchToexcelFile = "" + @filePath;
            ExcelQueryFactory excelFile = new ExcelQueryFactory(patchToexcelFile);
            var months = excelFile.GetWorksheetNames();
            excelFile.Dispose();
            return months;
        }
        public List<IQueryable<Daftarcs>> getDataFromFile(string filePath)
        {
            try
            {
                List<IQueryable<Daftarcs>> excelData = new List<IQueryable<Daftarcs>>();

                string patchToexcelFile = "" + @filePath;

                ExcelQueryFactory excelFile = new ExcelQueryFactory(patchToexcelFile);

                var months = excelFile.GetWorksheetNames();

                foreach (var month in months)
                {
                    var colname = getColumnsName(month, excelFile).ToList();
                    excelFile.AddMapping<Daftarcs>(x => x.CodeBudget, colname[0]);//کد بودجه
                    excelFile.AddMapping<Daftarcs>(x => x.DepositOwnerDetail, colname[1].ToString());//مشخصات صاحب سپرده
                    excelFile.AddMapping<Daftarcs>(x => x.AccountType, colname[2].ToString());//نوع حساب
                    excelFile.AddMapping<Daftarcs>(x => x.PlaceName, colname[3].ToString());//عنوان واحد ثبتی
                    excelFile.AddMapping<Daftarcs>(x => x.BillDetailCode, colname[4].ToString());//شماره قبض سپرده
                    excelFile.AddMapping<Daftarcs>(x => x.Date, colname[5].ToString());//تاریخ
                    excelFile.AddMapping<Daftarcs>(x => x.DepositDetail, colname[6].ToString());//کد مشخصات سپرده
                    excelFile.AddMapping<Daftarcs>(x => x.Deposit, colname[7].ToString());//واریزی
                    excelFile.AddMapping<Daftarcs>(x => x.Refund, colname[8].ToString());//استرداد

                    var monthData = from a in
                                 excelFile.WorksheetRange<Daftarcs>("A2", "J1000", month.ToString())
                                    select a;
                  excelData.Add(monthData);
                }
               excelFile.Dispose();
               return excelData;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        public List<IQueryable<Daftarcs>> ignoreBlanksRow(List<IQueryable<Daftarcs>> excelData)
        {
            List<IQueryable<Daftarcs>> cleanSheets = new List<IQueryable<Daftarcs>>();

            foreach (var sheet in excelData)
            {
                IQueryable<Daftarcs> cleanSheet = null;
                var x = sheet;
                try
                {
                    cleanSheet = from a in
                            x.Where(z => z.DepositOwnerDetail != null && z.Date != null && z.CodeBudget != null)
                                 select a;

                }
                catch (Exception )
                {
                  //  MessageBox.Show(exp.ToString());
                }
                cleanSheets.Add(cleanSheet);
            }
            return cleanSheets;
        }
        private List<long> findDuplicateID(List<long> list)
        {
            var query = list.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();
            foreach(var a in query)
            {
                
                MessageBox.Show("شناسه یکسان یافت شد  "+a.ToString());
            }
            return query;
        }
        public IQueryable<Daftarcs> dataCorrection(IQueryable<Daftarcs> data)
        {
            Utility util = new Utility();
            var convertedData = util.convertYekeQuery(data.ToList());
            convertedData = util.convertToRealDate(convertedData);
            var query = convertedData.AsQueryable();
            return query;
        }
          public ExcelValidationClass check(List<IQueryable<Daftarcs>> excelData, string fileName)
           {
            bool valid = true;
            List<string> errs = new List<string>();
            List<string> list = new List<string>();
            List<IQueryable<Daftarcs>> cleanSheets = new List<IQueryable<Daftarcs>>();
            foreach (var sheet in excelData)
            {
                IQueryable<Daftarcs> cleanSheet = null;

                var x = sheet;
                try
                {
                    cleanSheet = from a in
                            sheet.Where(z => z.DepositOwnerDetail != null && z.Date != null && z.CodeBudget != null)
                                 select a;
                }
                catch (Exception )
                {
                    valid = false;
                  //  MessageBox.Show(exp.ToString());
                }
                try
                {
                    string msg = " ";
                    int i = 0;
                    List<long> ids = new List<long>();

                    foreach (var a in cleanSheet)
                    {
                        i++;
                        Utility utl = new Utility();

                        long id = utl.idGenerator(1, a.Date, Convert.ToInt64(a.BillDetailCode));
                        ids.Add(id);

                        if ( a.BillDetailCode == 0 ||  !utl.isvalidDate(a.Date))
                        {
                            string spc = " ";
                            int j = i + 2;
                            msg = " سطر  "+spc+j.ToString() + spc+a.DepositOwnerDetail.ToString() +spc+ "حاوی مقادیر اشتباه است " ;
                            list.Add(msg);
                            valid = false;

                        }
                    }
                    var t = findDuplicateID(ids);
                    foreach (var a in t ) {
                        list.Add(a.ToString()+" دارای مشخصات یکسان است");
                    }

                }
                catch (Exception )
                {
                  //  MessageBox.Show(ex.ToString());
                    valid = false;
                }
            }
            list.Add(" خطا در فایل " + fileName);
            list.Add("   ");
            ExcelValidationClass validation = new ExcelValidationClass();
            validation.report = list;
            validation.isValid = valid;
            return validation;
    
           }
    }
}
