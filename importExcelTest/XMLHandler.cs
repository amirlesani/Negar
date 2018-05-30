using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace negar
{
    class XMLHandler
    {
        private string rootFile ;
       public XMLHandler()
        {
            try
            {
                var root  =AppDomain.CurrentDomain.BaseDirectory;
                rootFile = root+@"\daftar.xml";
            }
            catch(Exception )
            {
                MessageBox.Show("خطا در آدرس دهی");
            }
        }
        private void writeXmlData(XElement data)
        {
            try {
                if (File.Exists(rootFile))
                {

                        var x = XElement.Load(rootFile);
                        
                    
                        x.Add(data.Element("DaftarTable"));
                        x.Save(rootFile);
                    
                        //stream.Close();
                  
                }
                else
                {   

                        data.Save(rootFile);
                    
                        
                        //CreateIsf.Close();
                  
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        
        public bool addToNoteBook(List<DaftarTable> dataList)
        {
            List<string> report = new List<string>();
             
            try {
                if (File.Exists(rootFile))
                {
                    var query = loadXMLData();
                    if (query.Any())
                    {
                        Utility utl = new Utility();
                        foreach (var d in dataList)
                        {
                            if (query.Where(x => x.Id == d.Id).Any())
                            {
                                report.Add("شناسه در لیست وجود دارد" + " " + d.Id);
                                Report rpt = new Report(report, 1);
                                rpt.Show();
                                return false;
                            }
                        }
                    }
                }

                var datas = dataList.AsQueryable();

                foreach(var data in datas)
                {
                    report.Add(data.Id.ToString()+""+" به دفتر اضافه شد ");
                    XElement xml = new XElement("Root",
                                    new XElement("DaftarTable",
                                    new XElement("AccountType", data.AccountType),
                                    new XElement("BillDetailCode", data.BillDetailCode),
                                    new XElement("CityID", data.CityID),
                                    new XElement("CodeBudget", data.CodeBudget),
                                    new XElement("Date", data.Date),
                                    new XElement("Deposit", data.Deposit),
                                    new XElement("DepositDetail", data.DepositDetail),
                                    new XElement("DepositOwnerDetail", data.DepositOwnerDetail),
                                    new XElement("Refund", data.Refund),
                                    new XElement("RealDate", data.RealDate),
                                    new XElement("PlaceName", data.PlaceName),
                                    new XElement("Id", data.Id)
                                    
                                    )
                                );
                    writeXmlData(xml);
                }
                
                Report rpt2 = new Report(report, 0);
                rpt2.Show();
                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public bool remove(List<DaftarTable> dt)
        {
            if(File.Exists(rootFile))
            {
                try {
                    XElement data = XElement.Load(rootFile);
                    
                    foreach (var d in dt)
                    {
                         data.Elements().Where(x => x.Element("Id").Value == d.Id.ToString()).ToList().Remove() ;
                        
                    }
                    if(File.Exists(rootFile))
                    {
                        data.Save(rootFile);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
            return true;
        }
       
        private IQueryable<DaftarTable> ConvertElementToQuery(XElement data)
        {
            var d = data.Elements();
            List<DaftarTable> listData = new List<DaftarTable>();
            try
            {
                foreach (var a in d)
                {
                    DaftarTable readXml = new DaftarTable();
                    readXml.AccountType = a.Element("AccountType").Value;
                    readXml.BillDetailCode = Convert.ToInt64(a.Element("BillDetailCode").Value);
                    readXml.CityID = Convert.ToInt64(a.Element("CityID").Value);
                    readXml.CodeBudget = Convert.ToInt64(a.Element("CodeBudget").Value);
                    readXml.Date = a.Element("Date").Value;
                    readXml.Deposit = Convert.ToInt64(a.Element("Deposit").Value);
                    readXml.DepositDetail = Convert.ToInt64(a.Element("DepositDetail").Value);
                    readXml.DepositOwnerDetail = a.Element("DepositOwnerDetail").Value;
                    readXml.PlaceName = a.Element("PlaceName").Value;
                    readXml.Refund = Convert.ToInt64(a.Element("Refund").Value);
                    readXml.RealDate = Convert.ToInt64(a.Element("RealDate").Value);
                    readXml.Id = Convert.ToInt64(a.Element("Id").Value);
                    listData.Add(readXml);
                }
                return listData.AsQueryable() ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return listData.AsQueryable();
            }

        }
        public IQueryable<DaftarTable> loadXMLData()
        {
            
                XElement data = XElement.Load(rootFile) ;
                var query = ConvertElementToQuery(data);
                return query;
          

        }
        public bool isFileExist()
        {   
            return File.Exists(rootFile);
        }
        
    }
}
