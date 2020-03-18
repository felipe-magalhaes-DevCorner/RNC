using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer;

namespace RNC.comunicacao
{
    public class PDFVIumPrint
    {
        public  PDFVIumPrint(string filepath)
        {
            PrintPDF(filepath);
        }
        public bool PrintPDF(string filename)
        {


            try
            {


                // Now print the PDF document
                using (var document = PdfDocument.Load(filename))
                {
                    using (var printDocument = document.CreatePrintDocument())
                    {
                        PrintDialog pdi = new PrintDialog();

                        if (pdi.ShowDialog() == DialogResult.OK)
                        {
                            printDocument.PrinterSettings = pdi.PrinterSettings;
                            printDocument.DefaultPageSettings = pdi.PrinterSettings.DefaultPageSettings;
                            printDocument.PrintController = new StandardPrintController();
                            printDocument.Print();

                        }
                        else
                        {
                            MessageBox.Show("Print Cancelled");
                        }




                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
