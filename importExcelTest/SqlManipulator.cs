
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PersianDate;
using WindowsFormsApplication1;
using System.Data.Linq;
using System.Xml.Linq;

namespace negar
{
    class SqlManipulator
    {
        string cn;
        public SqlManipulator()
        {

            cn = Properties.Settings.Default.MainConnectionString;
        }
        public void notify(int userid)
        {

            
            Report sender = new Report();
            sender.Text = "حالت شنیدن";
            sender.Show();
            
            
            // See constructor optional parameters to configure it according to your needs                
                var listener = new SqlDependencyEx(cn, "Mali", "DaftarTable",identity: userid);
                // e.Data contains actual changed data in the XML format
                listener.TableChanged += (o, e) => sender.addItem(e.Data);

                listener.Start();

            //Your code here
            


            // After you call the Start method you will receive table notifications with 
            // the actual changed data in the XML format
            


            // ... Your code is here 

            // Don'refundStatus forget to stop the listener somewhere!
            //listener.Stop();
        }
        
        public MaxMinClass findMaxminMonthDay(long cityID)
        {
            MaxMinClass minmax = new MaxMinClass();

            try
            {
                if (cityID == 0)
                {
                    DaftarModelDataContext db = new DaftarModelDataContext(cn);
                    var q = from row in db.DaftarTables
                            group row by true into r
                            select new { min = r.Min(z => z.RealDate), max = r.Max(z => z.RealDate) };
                    foreach (var a in q)
                    {
                        minmax.max = a.max.Value;
                        minmax.min = a.min.Value;

                    }
                    return minmax;

                }
                else {
                    DaftarModelDataContext db = new DaftarModelDataContext(cn);
                    var p = from row in db.DaftarTables.Where(z => z.CityID == cityID)
                            group row by true into r
                            select new { min = r.Min(z => z.RealDate), max = r.Max(z =>z.RealDate) };
                    foreach (var a in p)
                    {
                        minmax.max = a.max.Value;
                        minmax.min = a.min.Value;

                    }
                    return minmax;
                }
            }catch(Exception)
            {
                throw;
            }


        }
        public StartEndMonthClass findMinMaxInQuert(IQueryable<Daftarcs> data)
        {
            StartEndMonthClass minmax = new StartEndMonthClass();

            try
            {
                    DaftarModelDataContext db = new DaftarModelDataContext(cn);
                    var q = from row in data
                            group row by true into r
                            select new { min = r.Min(z => z.RealDate), max = r.Max(z => z.RealDate) };
                    foreach (var a in q)
                    {
                        minmax.endDate = a.max;
                        minmax.startDate = a.min;
                    }
                    return minmax;               
            }
            catch (Exception)
            {
                throw;
            }


        }
        public Boolean addCity(CityTable newCity)
        {
            try
            {
                UserManagerDataClassesDataContext db = new UserManagerDataClassesDataContext(cn);
                db.CityTables.InsertOnSubmit(newCity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public List<string> addUser(UserTable newLogin)
        {
            try
            {
                UserManagerDataClassesDataContext db = new UserManagerDataClassesDataContext(cn);
                db.UserTables.InsertOnSubmit(newLogin);
                db.SubmitChanges();
                List<string> report = new List<string>();
                report.Add(newLogin.User + "" + "  با موفقیت اضافه گردید");
                return report;
            }
            catch (System.Data.SqlClient.SqlException  )
            {
                // DaftarModelDataContext db = new DaftarModelDataContext(cn);
                List<string> report = new List<string>();
                report.Add(newLogin.User+ "" + " نام کاربری تکراری است");
                return report; 
            }
        }
        public List<string> addValidation(validationTable newRestriction)
        {
            try
            {
                ValidationDataClassesDataContext db = new ValidationDataClassesDataContext(cn);
                db.validationTables.InsertOnSubmit(newRestriction);
                db.SubmitChanges();
                List<string> report = new List<string>();
                report.Add(newRestriction.description + "" + "  با موفقیت اضافه گردید");
                return report;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                // DaftarModelDataContext db = new DaftarModelDataContext(cn);
                List<string> report = new List<string>();
                report.Add("خطا در اضافه کردن محدودیت");
                return report;
            }
        }

        public Boolean removeUser(UserTable newLogin)
        {
            try
            {
                UserManagerDataClassesDataContext db = new UserManagerDataClassesDataContext(cn);
                var q = from a in db.UserTables where a.Id == newLogin.Id select a;
                foreach (var a in q)
                {
                    db.UserTables.DeleteOnSubmit(a);
                }

                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;

            }
        }
        public Boolean removeCity(CityTable newCity)
        {
            try
            {
                UserManagerDataClassesDataContext db = new UserManagerDataClassesDataContext(cn);
                var q = from a in db.CityTables where a.Id == newCity.Id select a;
                foreach (var a in q)
                {
                    db.CityTables.DeleteOnSubmit(a);
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public Boolean removeRestriction(validationTable restriction)
        {
            try
            {
                ValidationDataClassesDataContext db = new ValidationDataClassesDataContext(cn);
                var q = from a in db.validationTables where a.id == restriction.id select a;
                foreach (var a in q)
                {
                    db.validationTables.DeleteOnSubmit(a);
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        public IQueryable getDataLogin()
        {


            UserManagerDataClassesDataContext db = new UserManagerDataClassesDataContext(cn);
            var q = from c in db.UserTables
                    join d in db.CityTables on c.City equals d.Id
                    select new
                    {
                        c.Id,c.Name,c.Family,c.User,c.Password,c.Permission,d.CityName };
            return q;
        }
        public IQueryable getDataCity()
        {
            UserManagerDataClassesDataContext db = new UserManagerDataClassesDataContext(cn);
            var q = from c in db.CityTables select new {c.CityName,c.Id };
            return q;
        }
        public IQueryable getValidationData()
        {
            ValidationDataClassesDataContext db = new ValidationDataClassesDataContext(cn);
            
            var q = from c in db.validationTables
                    select new
                    {
                        c.id,
                        c.description,
                        c.City,
                        c.startDate,
                        c.enDate,
                    };
            return q;
        }
        public IQueryable getValidationDataByCityandDate(int cityID,long startDate,long endDate)
        {
            ValidationDataClassesDataContext db = new ValidationDataClassesDataContext(cn);
            var q = from c in db.validationTables.Where(x=>x.id == cityID && x.startDate ==startDate && x.enDate == endDate) 
                    select new 
                    {
                        c.id,
                        c.description,
                        c.City,
                        c.startDate,
                        c.enDate,
                    };
            return q;
            
        }



        public string getCityName(long cityID)
        {
            UserManagerDataClassesDataContext db = new UserManagerDataClassesDataContext(cn);
            var q = from c in db.CityTables select new { c.CityName, c.Id };

            foreach(var a in q )
            {
                if(a.Id == cityID)
                {
                    return a.CityName;
                }
            }
            return "not found";

        }
        public List<string> refundFromFile(IQueryable<Daftarcs> excelQuery, long cityID)
        {
            try
            {
                List<string> report = new List<string>();
                Utility utl = new Utility();
                
                DaftarModelDataContext db =
                new DaftarModelDataContext(cn);
                List<DaftarTable> listDaftar = new List<DaftarTable>();
                StartEndMonthClass date =  findMinMaxInQuert(excelQuery);
                foreach (var row in excelQuery)
                {
                    DaftarTable newDaftar = new DaftarTable();
                    newDaftar.DepositOwnerDetail = row.DepositOwnerDetail;
                    newDaftar.PlaceName = row.PlaceName;
                    newDaftar.AccountType = row.AccountType;
                    newDaftar.Date = row.Date;
                    newDaftar.RealDate = utl.changeToRealDate(newDaftar.Date);
                    newDaftar.BillDetailCode = Convert.ToInt64(row.BillDetailCode);
                    newDaftar.CodeBudget = Convert.ToInt64(row.CodeBudget);
                    newDaftar.Deposit = Convert.ToInt64(row.Deposit);
                    newDaftar.DepositDetail = Convert.ToInt64(row.DepositDetail);
                    newDaftar.Refund = Convert.ToInt64(row.Refund);
                    newDaftar.Id = utl.idGenerator(cityID, newDaftar.Date, newDaftar.BillDetailCode);
                    newDaftar.CityID = cityID;
                    listDaftar.Add(newDaftar);
                }
                var query = listDaftar.AsQueryable();                
                var search = (from c in db.DaftarTables.Where(x => x.CityID == cityID && x.RealDate >= date.startDate && x.RealDate <= date.endDate) select c);

                
                foreach (var b in query)
                {
                    bool refunded = false;
                    foreach (var a in search)
                    {

                        if (a.Id == b.Id)
                        {
                            if (b.Refund != 0 && b.Deposit == 0 && a.Refund == 0)
                            {
                                a.Refund = a.Deposit;
                                a.Deposit = 0;
                                report.Add(a.DepositOwnerDetail + " " + a.Id + "استرداد شد");
                                refunded = true;   
                            }
                        }
                    }

                    if(!refunded)
                    {                                 
                        report.Add(b.DepositOwnerDetail + " " + b.Id + "خطا در استرداد");
                    }
                    

                }
                db.SubmitChanges();
                excelQuery = null;
                return report;
            }
            catch (Exception ex)
            {
                string exp = "خطا";
                List<string> report = new List<string>();
                report.Add(ex.ToString());
                report.Add(exp);
                return report;
            }
        }
        
        public Boolean excelToSqlCopy(IQueryable<Daftarcs> excelQuery, long cityID)
        {
            try
            {
                Utility utl = new Utility();

                DaftarModelDataContext db =
                new DaftarModelDataContext(cn);
                List<DaftarTable> listDaftar = new List<DaftarTable>();
                foreach (var row in excelQuery)
                {
                    DaftarTable newDaftar = new DaftarTable();
                    newDaftar.DepositOwnerDetail = row.DepositOwnerDetail;
                    newDaftar.PlaceName = row.PlaceName;
                    newDaftar.AccountType = row.AccountType;
                    newDaftar.Date = row.Date;
                    newDaftar.RealDate = utl.changeToRealDate(newDaftar.Date);
                    newDaftar.BillDetailCode = Convert.ToInt64(row.BillDetailCode);
                    newDaftar.CodeBudget = Convert.ToInt64(row.CodeBudget);
                    newDaftar.Deposit = Convert.ToInt64(row.Deposit);
                    newDaftar.DepositDetail = Convert.ToInt64(row.DepositDetail);
                    newDaftar.Refund = Convert.ToInt64(row.Refund);

                    newDaftar.Id = utl.idGenerator(cityID, newDaftar.Date, newDaftar.BillDetailCode);
                    newDaftar.CityID = cityID;
                    listDaftar.Add(newDaftar);
                }
                db.BulkInsertAll(listDaftar);
                excelQuery = null;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public IQueryable<CityTable> queryCities()
        {
            try
            {
                UserManagerDataClassesDataContext db = new UserManagerDataClassesDataContext(cn);
                var q = from c in db.CityTables select c;
                return q;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

       
        public Result pageResult(Result result,int pageNumber , int pageSize)
        {
            ///split search result 
            ///
            Result p = new Result();
             p.query = (from c in result.query select c).Page(pageSize,pageNumber);
             p.queryPageNumber   = result.query.Count()/pageSize;
             return p;
        }

        
        public Result searchByDate(long cityID,int pageSize ,long start, long end)
        {
            Result result = new Result();
            DaftarModelDataContext db = new DaftarModelDataContext(cn);
            Utility utl = new Utility();
   
            if (cityID == 0)
            {
                var query = (from c in db.DaftarTables.Where(x => x.RealDate >= start && x.RealDate <=end) select c);
                var count = query.Count();
                result.recordCount = count;
                result.queryPageNumber =count/ pageSize;
                result.query = query;
                return result;
            }
             
                var query2 = (from c in db.DaftarTables.Where(x=>x.CityID == cityID && x.RealDate>=start && x.RealDate<=end) select c);
                var count2 = query2.Count();
                result.recordCount = count2;
                result.queryPageNumber = count2 / pageSize;
                result.query = query2;
                return result;

        }
       public Boolean isRestricted(DaftarTable data,bool permission)
        {
            try {
                if (permission)
                    return false;
                ValidationDataClassesDataContext db = new ValidationDataClassesDataContext(cn);
                var valid = (from c in db.validationTables.Where(x => x.City == data.CityID && data.RealDate>= x.startDate && data.RealDate<= x.enDate ) select c).Any();
                
                return valid;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            
        }
        public List<String> addRow(DaftarTable daftar)
        {
            try
            {
                List<string> report = new List<string>();
                DaftarModelDataContext db = new DaftarModelDataContext(cn);
                db.DaftarTables.InsertOnSubmit(daftar);
                db.SubmitChanges();
                string person = daftar.Id.ToString()+" " + daftar.DepositOwnerDetail.ToString();
                report.Add(" با موفقیت اضافه گردید"+" "+person);
                return report;


            }

            //duplicate record
            catch (System.Data.SqlClient.SqlException ex)
            {
               // MessageBox.Show(ex.ToString()); 
                // DaftarModelDataContext db = new DaftarModelDataContext(cn);
                List<string> report = new List<string>();
                report.Add(daftar.Id + "" + " شناسه تکراری است . تاریخ یا کد سپرده می بایست متفاوت باشد" );
                return report;
            }

            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //    return false;
            //}

        }
        public List<string> remove(List<DaftarTable> newDaftar, bool godmode,bool permision)
        {
            IQueryable<DaftarTable> data;
            data = null;
            DaftarModelDataContext db = new DaftarModelDataContext(cn);
            List<string> report = new List<string>();
            report.Add("لیست  زیر");
            int count = 0;
            foreach (var daftar in newDaftar)
            {
                count++;
                data = from a in db.DaftarTables.Where(x => x.Id == daftar.Id) select a;
                foreach (var a in data)
                {
                    if (Math.Abs(Convert.ToInt64(a.Refund)) > 0 && !godmode)
                    {
                        report.Add(a.Id.ToString() + " " + a.DepositOwnerDetail.ToString() + " استرداد شده است! غیر قابل ویرایش می باشد  ");
                    }
                    else {
                        if (isRestricted(daftar,permision))
                        {
                            string msg = " دسترسی شما به این تاریخ توسط مدیر سیستم محدود شده است";
                            report.Add(a.Id + " " + a.DepositOwnerDetail + " " + msg);
                        }
                        else
                        {
                            db.DaftarTables.DeleteOnSubmit(a);
                            string msg = " حذف گردید  ";
                            report.Add(a.Id + " " + a.DepositOwnerDetail + " " + msg);
                        }
                    }
                }
            }

            try
            {
                db.SubmitChanges();
                return report;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                report.Add("خطا در حذف");
                return report;
            }

        }
        public List<string> update(DaftarTable daftar,bool godmode)
        {
            try
            {

                DaftarModelDataContext db = new DaftarModelDataContext(cn);
                var data = from a in db.DaftarTables.Where(x => x.Id == daftar.Id) select a;
                List<string> list = new List<string>();
                list.Add("شناسه های ");
                foreach (var a in data)
                {
                    if ((Math.Abs(Convert.ToInt64(a.Refund))) > 0 && !godmode)
                    {
                        list.Add(a.Id.ToString() + " " + a.DepositOwnerDetail.ToString() + " استرداد شده است! غیر قابل ویرایش می باشد  ");
                    }
                    else
                    {
                        a.Id = daftar.Id;
                        //a.PlaceName = daftar.PlaceName;
                        //a.CityID = daftar.CityID;
                        a.Refund = daftar.Refund;
                        //a.Date = daftar.Date;
                        a.Deposit = daftar.Deposit;
                        a.DepositDetail = daftar.DepositDetail;
                        a.DepositOwnerDetail = daftar.DepositOwnerDetail;
                        a.CodeBudget = daftar.CodeBudget;
                        a.AccountType = daftar.AccountType;
                        //  a.RealDate = daftar.RealDate;
                        // a.BillDetailCode = daftar.BillDetailCode;
                        list.Add(a.Id.ToString()+" " + a.DepositOwnerDetail.ToString() + " با موفقیت بروزرسانی شد ");
                    }
                }
                db.SubmitChanges();

                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                List<string> list = new List<string>();
                Report rpt = new Report(list, (int)errorImages.info);
                rpt.Show();
                return list;
            }
        }
        public Result ownerQuery(long cityID, string code, StartEndMonthClass startend, int pageSize)
        {
            DaftarModelDataContext db = new DaftarModelDataContext(cn);

            Result result = new Result();
            if (cityID == 0)
            {
                var query = (from c in db.DaftarTables.Where(x => x.RealDate >= startend.startDate &&
                             x.RealDate <= startend.endDate && x.DepositOwnerDetail.ToString().Contains(code))
                             select c);
                var count = query.Count();
                result.recordCount = count;
                result.queryPageNumber = count/ pageSize;
                
                result.query = query;
                return result;
            }

            var query2 = (from c in db.DaftarTables.Where(x => x.CityID == cityID &&
                          x.RealDate >= startend.startDate &&
                          x.RealDate <= startend.endDate
                          && x.DepositOwnerDetail.ToString().Contains(code))
                          select c);
            var count2 = query2.Count();
            result.recordCount = count2;
            result.queryPageNumber = count2 / pageSize;
            result.query = query2;
            return result;
        }
        public Result budgetCodeQuery(long cityID ,string code , StartEndMonthClass startend, int pageSize)
        {
            DaftarModelDataContext db = new DaftarModelDataContext(cn);

            Result  result = new Result();
            if (cityID == 0)
            {
                var query = (from c in db.DaftarTables.Where(x => x.RealDate >= startend.startDate && 
                             x.RealDate <= startend.endDate &&  x.CodeBudget.ToString().Contains(code)) select c);
                var count = query.Count();
                result.queryPageNumber =count/ pageSize;
                result.recordCount = count;
                result.query = query;
                return result;
            }

            var query2 = (from c in db.DaftarTables.Where(x => x.CityID == cityID &&
                          x.RealDate >= startend.startDate &&
                          x.RealDate <= startend.endDate
                          && x.CodeBudget.ToString().Contains(code)) select c);
            var count2 = query2.Count();
            result.recordCount = count2;
            result.queryPageNumber = count2 / pageSize;
            result.query = query2;
            return result;
        }
        //نوع حساب
        //شماره قبض
        //کد مشخصات سپرده
        //واریزی
        //استرداد
        public Result AccountTypeQuery(long cityID, string accountTypeQuery, StartEndMonthClass startend, int pageSize)
        {
            DaftarModelDataContext db = new DaftarModelDataContext(cn);

            Result result = new Result();
            if (cityID == 0)
            {
                var query = (from c in db.DaftarTables.Where(x => x.RealDate >= startend.startDate &&
                             x.RealDate <= startend.endDate && x.AccountType.ToString().Contains(accountTypeQuery))
                             select c);
                var count = query.Count();
                result.recordCount = count;
                result.queryPageNumber =count/ pageSize;
                result.query = query;
                return result;
            }

            var query2 = (from c in db.DaftarTables.Where(x => x.CityID == cityID &&
                          x.RealDate >= startend.startDate &&
                          x.RealDate <= startend.endDate
                          && x.AccountType.ToString().Contains(accountTypeQuery))
                          select c);
            var count2 = query2.Count();
            result.recordCount = count2;
            result.queryPageNumber = count2 / pageSize;
            result.query = query2;
            return result;
        }
        public Result billDetailCodeQuery(long cityID, string code, StartEndMonthClass startend, int pageSize)
        {
            DaftarModelDataContext db = new DaftarModelDataContext(cn);

            Result result = new Result();
            if (cityID == 0)
            {
                var query = (from c in db.DaftarTables.Where(x => x.RealDate >= startend.startDate &&
                             x.RealDate <= startend.endDate && x.BillDetailCode.ToString().Contains(code))
                             select c);
                var count = query.Count();
                result.recordCount = count;
                result.queryPageNumber =count/ pageSize;
                result.query = query;
                return result;
            }

            var query2 = (from c in db.DaftarTables.Where(x => x.CityID == cityID &&
                          x.RealDate >= startend.startDate &&
                          x.RealDate <= startend.endDate
                          && x.BillDetailCode.ToString().Contains(code))
                          select c);
            var count2 = query2.Count();
            result.recordCount = count2;
            result.queryPageNumber = count2 / pageSize;
            result.query = query2;
            return result;
        }
        public Result depositDetailCodeQuery(long cityID, string code, StartEndMonthClass startend, int pageSize)
        {
            DaftarModelDataContext db = new DaftarModelDataContext(cn);

            Result result = new Result();
            if (cityID == 0)
            {
                var query = (from c in db.DaftarTables.Where(x => x.RealDate >= startend.startDate &&
                             x.RealDate <= startend.endDate && x.DepositDetail.ToString().Contains(code))
                             select c);
                var count = query.Count();
                result.queryPageNumber =count/ pageSize;
                result.recordCount = count;
                result.query = query;
                return result;
            }

            var query2 = (from c in db.DaftarTables.Where(x => x.CityID == cityID &&
                          x.RealDate >= startend.startDate &&
                          x.RealDate <= startend.endDate
                          && x.DepositDetail.ToString().Contains(code))
                          select c);
            var count2 = query2.Count();
            result.recordCount = count2;
            result.queryPageNumber = count2 / pageSize;
            result.query = query2;
            return result;
        }
        public Result depositQuery(long cityID, string code, StartEndMonthClass startend, int pageSize)
        {
            DaftarModelDataContext db = new DaftarModelDataContext(cn);

            Result result = new Result();
            if (cityID == 0)
            {
                var query = (from c in db.DaftarTables.Where(x => x.RealDate >= startend.startDate &&
                             x.RealDate <= startend.endDate && x.Deposit.ToString().Contains(code))
                             select c);
                var count = query.Count();
                result.recordCount = count;
                result.queryPageNumber =count/ pageSize;
                result.query = query;
                return result;
            }

            var query2 = (from c in db.DaftarTables.Where(x => x.CityID == cityID &&
                          x.RealDate >= startend.startDate &&
                          x.RealDate <= startend.endDate
                          && x.Deposit.ToString().Contains(code))
                          select c);
            var count2 = query2.Count();
            result.recordCount = count2;
            result.queryPageNumber = count2 / pageSize;
            result.query = query2;
            return result;
        }
        public Result refundQuery(long cityID, string code, StartEndMonthClass startend, int pageSize)
        {
            DaftarModelDataContext db = new DaftarModelDataContext(cn);

            Result result = new Result();
            if (cityID == 0)
            {
                var query = (from c in db.DaftarTables.Where(x => x.RealDate >= startend.startDate &&
                             x.RealDate <= startend.endDate && x.Refund.ToString().Contains(code))
                             select c);
                var count = query.Count();
                result.recordCount = count;
                result.queryPageNumber =count/ pageSize;
                result.query = query;
                return result;
            }

            var query2 = (from c in db.DaftarTables.Where(x => x.CityID == cityID &&
                          x.RealDate >= startend.startDate &&
                          x.RealDate <= startend.endDate
                          && x.Refund.ToString().Contains(code))
                          select c);
            var count2 = query2.Count();
            result.recordCount = count2;
            result.queryPageNumber = count2 / pageSize;
            result.query = query2;
            return result;
        }

        public List<string> refund(List<DaftarTable> newDaftar,bool godmode)
        {

            IQueryable<DaftarTable> data;
            data = null;
            DaftarModelDataContext db = new DaftarModelDataContext(cn);
            List<string> report = new List<string>();
            foreach (var daftar in newDaftar)
            {
                data = from a in db.DaftarTables.Where(x => x.Id == daftar.Id) select a;
                foreach (var a in data)
                {   
                    //if(isRestricted(a))
                    //{
                    //    report.Add(a.Id.ToString() + " " + a.DepositOwnerDetail + " " + "دسترسی توسط مدیر سیستم محدود شده است ");

                    //}else if
                    //
                     if(a.Deposit != 0 )
                    {
                        a.Refund = a.Deposit;
                        a.Deposit = 0;
                        report.Add(a.Id.ToString() + " " + a.DepositOwnerDetail + " " + "مسترد شد ");
                    }
                    else
                    {
                        report.Add(a.Id.ToString() + " " + a.DepositOwnerDetail + " " + "مبلغ قبلا مسترد شده است ");
                    }
                  
                }
            }
            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            return report;

        }
        public long sumPrice(Result result)
        {
            long prices = 0;
            foreach(var a in result.query)
            {
                prices = prices + Convert.ToInt64(a.Deposit);
            }
            return prices;
        }
        public DateTime persianDate(long date)
        {
            CultureInfo info = new CultureInfo("fa-Ir");
            string stringDate = Convert.ToString(date);
            char[] dte = stringDate.ToCharArray();
            int year = Convert.ToInt16(dte[0].ToString() + dte[1].ToString());
            int month = Convert.ToInt16(dte[2].ToString() + dte[3].ToString());
            int day = Convert.ToInt16(dte[4].ToString() + dte[5].ToString());
            importExcelTests.PersianCultureHelper.SetPersianOptions(info);
            Thread.CurrentThread.CurrentCulture = info;
            DateTime dt2 =
            info.Calendar.ToDateTime(year, month, day, 0, 0, 0, 0);
            return dt2;
        }
    }
    static class PagingUtils
    {
        public static IEnumerable<T> Page<T>(this IEnumerable<T> en, int pageSize, int page)
        {
            return en.Skip(page * pageSize).Take(pageSize);
        }
        public static IQueryable<T> Page<T>(this IQueryable<T> en, int pageSize, int page)
        {
            return en.Skip(page * pageSize).Take(pageSize);
        }
    }
    public static class XElementExtension
    {
        public static string InnerXML(this XElement el)
        {
            var reader = el.CreateReader();
            reader.MoveToContent();
            return reader.ReadInnerXml();
        }
    }
}
