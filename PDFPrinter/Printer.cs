using System;
using System.Collections.Generic;
using System.Text;
using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using PDFPRinter;

namespace PDFPrinter
{
    public class Printer
    {

        private string outputfile = AppDomain.CurrentDomain.BaseDirectory + "test.pdf";
        private string imgpath = AppDomain.CurrentDomain.BaseDirectory + "Pictures\\LOGOMARCA - GMN.jpg";
        private relatorio relatorioInUse { get; set; }
        public void printPDF(relatorio relatorioUsing)
        {
            relatorioInUse = relatorioUsing;
            ManipulatePDF(relatorioInUse);

        }

        private void ManipulatePDF(relatorio relatorio)
        {
            PdfDocument pdfDoc = new PdfDocument(new
                PdfWriter(outputfile));

            Document doc = new Document(pdfDoc);
            //table settings
            Table table = new Table(UnitValue.CreatePercentArray(new float[] {10}));
            table.SetWidth( UnitValue.CreatePercentValue(100));
            table.SetTextAlignment(TextAlignment.CENTER);

            GenerateHeader(table);


            doc.Add(table);
            doc.Close();


        }
        private void GenerateHeader(Table table)
        {

            #region CellWithImage
            //cell with image
            var cellwithImage = createImageCell(imgpath, 3,1);

            table.AddCell(cellwithImage);
            

            #endregion
           

            //

            //dealing with text
            Text gmnNameText = new Text("GMN Analises Laboratorias").SetFontSize(24).SetFontColor(ColorConstants.GRAY).SetFont(GetFont(1));
            Text rncTitle = new Text(String.Format("Relatorio de não conformidade")).SetFontSize(18).SetFontColor(ColorConstants.GRAY).SetFont(GetFont(1));
            Text RNCNumber = new Text(relatorioInUse.RNCNumber().ToString()).SetFontSize(16).SetFontColor(ColorConstants.GRAY);


            //adding to table
            


























        }
        #region Creators
        private static Cell createImageCell(String path, int rowspan, int colspan)
        {
            Image img = new Image(ImageDataFactory.Create(path));
            img.SetWidth(UnitValue.CreatePercentValue(100));
            Cell cell = new Cell(rowspan,colspan).Add(img);
            //cell.SetBorder(Border.NO_BORDER);

            return cell;
        }
        private static Cell createTextCell(String text)
        {
            Cell cell = new Cell();
            Paragraph p = new Paragraph(text);
            PdfFont font = GetFont();
            //cell.SetBorder(Border.NO_BORDER);

            //cell.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

            cell.Add(p);
            
            return cell;
        }
        private static Cell createTextCellBOLD(String text)
        {
            Cell cell = new Cell();
            Paragraph p = new Paragraph(text);
            PdfFont font = GetFont(1);
            //cell.SetBorder(Border.NO_BORDER);

            //cell.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

            cell.Add(p);
            
            return cell;
        }
        private static Cell createTextCell(Text text)
        {
            Cell cell = new Cell();
            Paragraph p = new Paragraph(text);

            PdfFont font = GetFont();
            //cell.SetBorder(Border.NO_BORDER);
            


            //cell.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

            cell.Add(p);
            return cell;
        }
        private static Cell createTextCellBOLD(Text text)
        {
            Cell cell = new Cell();
            Paragraph p = new Paragraph(text);
            PdfFont font = GetFont(1);
            //cell.SetBorder(Border.NO_BORDER);
            


            //cell.SetHorizontalAlignment(HorizontalAlignment.RIGHT);

            cell.Add(p);
            return cell;
        }
        protected LineSeparator LineSeparator(float linewitdh)
        {
            SolidLine line = new SolidLine(linewitdh);
            line.SetColor(iText.Kernel.Colors.ColorConstants.BLUE);
            LineSeparator ls = new LineSeparator(line);
            ls.SetMargin(0);

            return ls;

        }

        public static PdfFont GetFont(int font = 0)
        {
            if (font == 0)
            {
                return PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
                
            }
            else if (font == 1 )
            {
                return PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
            }
            else 
            {
                return PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLDOBLIQUE);
            }

           
                

        }
        private Cell getCell(int rowspawn, int columnspan) {
            Cell cell = new Cell(1, columnspan);
            return cell;
        }
        private Cell getCell(int cm, string text) {
            Cell cell = new Cell(1, cm);
            Paragraph p = new Paragraph(
                String.Format("%smm", 10 * cm)).SetFontSize(8);
            p.SetTextAlignment(TextAlignment.CENTER);
            cell.Add(p);
            return cell;
        }
        private Cell getCell(int cm, Text text) {
            Cell cell = new Cell(1, cm);
            Paragraph p = new Paragraph(
                String.Format("%smm", 10 * cm)).SetFontSize(8);
            p.SetTextAlignment(TextAlignment.CENTER);
            cell.Add(p);
            return cell;
        }
        #endregion

        public void SetRelatorio(object relatorio)
        {
            relatorioInUse = (relatorio) relatorio;
        }

       
    }
}
