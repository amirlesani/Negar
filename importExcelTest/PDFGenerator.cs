using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoddleReport;
using System.IO;
using DoddleReport.iTextSharp;
using System.Windows.Forms;


namespace negar
{
    class PDFGenerator
    {
     
        public PDFGenerator(IQueryable report,string path)
        {

            try {
                var rpt = new Report(report.ToReportSource());
                rpt.TextFields.Title = "اولین گزارش";
                rpt.TextFields.SubTitle = "in ye teste";

                

               // FileStream outputStream = new FileStream(@"C:\test2", FileMode.OpenOrCreate);
               var s = new FileStream(@"D:\\rt.pdf",FileMode.OpenOrCreate);
                PdfReportWriter pdfWriter = new PdfReportWriter();
                pdfWriter.WriteReport(rpt,s);
                


                //if (outputStream.CanRead && outputStream.CanWrite)
                //{
                //    Console.WriteLine("MyFile.txt can be both written to and read from.");
                //}
                //else if (outputStream.CanRead)
                //{
                //    Console.WriteLine("MyFile.txt is not writable.");
                //}
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }



    }



}
