using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RNC.comunicacao
{
    public class Printer
    {

        private Font printFont;
        private StreamReader streamToPrint;
        static string filePath;
        public Printer(string inFilepath)
        {
            filePath = inFilepath;
            Printing();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev) 
        {
            float linesPerPage = 0;
            float yPos =  0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            String line=null;
             
            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height  / 
                           printFont.GetHeight(ev.Graphics) ;
 
            // Iterate over the file, printing each line.
            while (count < linesPerPage && 
                   ((line=streamToPrint.ReadLine()) != null)) 
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString (line, printFont, Brushes.Black, 
                    leftMargin, yPos, new StringFormat());
                count++;
            }
 
            // If more lines exist, print another page.
            if (line != null) 
                ev.HasMorePages = true;
            else 
                ev.HasMorePages = false;
        }

        // Print the file.
        public void Printing()
        {
            try 
            {
                streamToPrint = new StreamReader (filePath);
                try 
                {
                    PrintDialog pdi = new PrintDialog();
                    printFont = new Font("Arial", 10);
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                    pdi.Document = pd;
                    if (pdi.ShowDialog() == DialogResult.OK)
                    {
                        pd.Print();
                    }
                    else
                    {
                        MessageBox.Show("Print Cancelled");
                    }
                    //// Print the document.
                    //pd.Print();
                } 
                finally 
                {
                    streamToPrint.Close() ;
                }
            } 
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
        }
   
        
    }
}
