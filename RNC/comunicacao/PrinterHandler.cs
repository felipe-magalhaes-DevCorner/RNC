using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Org.BouncyCastle.Crmf;
using PDFFilePrint;
using HorizontalAlignment = iText.Layout.Properties.HorizontalAlignment;
using Image = iText.Layout.Element.Image;

namespace RNC.comunicacao
{
    public class PrinterHandler
    {
        private string outputfile = AppDomain.CurrentDomain.BaseDirectory + "test.pdf";
        private string imgpath = AppDomain.CurrentDomain.BaseDirectory + "Resources\\LOGOMARCA - GMN.jpg";

        private relatorio relatorio;
        public void PDFPrinter(relatorio relatoriopass)
        {
            relatorio = relatoriopass;
            ManipulatePDF(relatorio);


            PDFVIumPrint printer = new PDFVIumPrint(outputfile);







            //FileInputStream fis = new FileInputStream(“C:/mypdf.pdf”);
            //Doc pdfDoc = new SimpleDoc(fis, null, null);
            //DocPrintJob printJob = printService.createPrintJob();
            //printJob.print(pdfDoc, new HashPrintRequestAttributeSet());
            //fis.close();






            //Printer printer = new Printer(outputfile);
          





            //FilePrint fileprint = new FilePrint(outputfile, null);
            //PrintDocument pd = new PrintDocument();
            //pd.PrintPage += new PrintPageEventHandler();
            //PrintDialog pdi = new PrintDialog();
            //pdi.Document = pd;
            //if (pdi.ShowDialog() == DialogResult.OK)
            //{
            //    PrinterSettings;
            //}
            //else
            //{
            //    MessageBox.Show("Print Cancelled");
            //}
            

            //PrintDialog dialogPrint = new PrintDialog();
            //dialogPrint.AllowPrintToFile = true;
            //dialogPrint.AllowSomePages = true;
            //dialogPrint.PrinterSettings.MinimumPage = 1;
            //dialogPrint.PrinterSettings.MaximumPage = doc.Pages.Count;
            //dialogPrint.PrinterSettings.FromPage = 1;
            //dialogPrint.PrinterSettings.ToPage = doc.Pages.Count;

            //if (dialogPrint.ShowDialog() == DialogResult.OK)
            //{
            //    doc.PrintFromPage = dialogPrint.PrinterSettings.FromPage;
            //    doc.PrintToPage = dialogPrint.PrinterSettings.ToPage;
            //    doc.PrinterName = dialogPrint.PrinterSettings.PrinterName;

            //    PrintDocument printDoc = doc.PrintDocument;
            //    dialogPrint.Document = printDoc;
            //    printDoc.Print();
            //}



            MessageBox.Show("Printing...");
        }



        #region Methods

        private void ManipulatePDF(relatorio relatorio1)
        {
            //creates temporary file, for pdf output frinting
            var pdfDoc = new PdfDocument(writer: new PdfWriter(outputfile));

            Document doc = new Document(pdfDoc);


            //generates header with logo RNC number and description
            GenerateHeader(doc);

            //manipulates all steps of body
            doc.Add(GenerateDescrição());

            //adds emitente information
            doc.Add(GenerateEmitente());


            //adds emitente information
            doc.Add(GenerateSingleLineFields());

            //handler for acao item
            GenerateAções(doc);
            PdfViewerPreferences preferences = new PdfViewerPreferences();


            doc.Close();

            pdfDoc.Close();



        }
        /// <summary>
        /// generates header with logo
        /// </summary>
        /// <param name="doc"></param>
        private void GenerateHeader(Document doc)
        {


            //table settings
            Table table = new Table(UnitValue.CreatePercentArray(new float[] { 3, 5 }));
            table.SetWidth(UnitValue.CreatePercentValue(100));
            table.SetTextAlignment(TextAlignment.CENTER);

            //border of whole table




            //cell with image
            var cellwithImage = createImageCell(imgpath);






            //dealing with text;
            Text Title = new Text("GMN Analises Laboratorias").SetFont(GetFont(1)).SetFontSize(24).SetFontColor(ColorConstants.GRAY);
            Text Title2 = new Text(String.Format("Relatorio de não conformidade")).SetFont(GetFont(1)).SetFontSize(18).SetFontColor(ColorConstants.GRAY);
            Text RNCNumber = new Text(relatorio.RNCNumber() + relatorio.GetStatus()).SetFontSize(16).SetFontColor(ColorConstants.GRAY).SetFont(GetFont());
            Cell groupname = new Cell(2, 5);
            Cell cell = new Cell();
            Paragraph p = new Paragraph(Title).SetVerticalAlignment(VerticalAlignment.MIDDLE);
            Paragraph p2 = new Paragraph(Title2).SetVerticalAlignment(VerticalAlignment.MIDDLE);
            Paragraph p3 = new Paragraph(RNCNumber).SetVerticalAlignment(VerticalAlignment.BOTTOM);
            PdfFont font = PdfFontFactory.CreateFont(FontConstants.HELVETICA);




            //addscell with text
            cell.Add(createTextCell("GMN Analises Laboratorias").SetFont(GetFont(1)).SetFontSize(24).SetFontColor(ColorConstants.GRAY));
            cell.Add(createTextCell("Relatorio de não conformidade")).SetFont(GetFont(1)).SetFontSize(18).SetFontColor(ColorConstants.GRAY);
            cell.Add(createTextCell(relatorio.RNCNumber().ToString())).SetFont(GetFont(1)).SetFontSize(16).SetFontColor(ColorConstants.GRAY); ;


            //borders
            table.SetBorder(new SolidBorder(ColorConstants.BLACK, 0));
            cellwithImage.SetBorder(new SolidBorder(ColorConstants.BLACK, 0));
            cell.SetBorder(new SolidBorder(ColorConstants.BLACK, 0));
            table.AddCell(cellwithImage.SetWidth(UnitValue.CreatePercentValue(15)));
            table.AddCell(cell);


            doc.Add(table);

        }

        /// <summary>
        /// generates first field of table
        /// </summary>
        /// <returns></returns>
        private Table GenerateDescrição()
        {
            //table settings
            Table table = new Table(UnitValue.CreatePercentArray(new float[] { 1 }));
            table.SetWidth(UnitValue.CreatePercentValue(100));
            table.SetTextAlignment(TextAlignment.CENTER);
            //descricao
            table.AddCell(createTextCell("Descrição da Não Conformidade (Real ou Potencial)").SetPaddingTop(7).SetPaddingBottom(7)
                .SetFont(GetFont(1)).SetFontSize(10)).SetBorder(new SolidBorder(ColorConstants.BLACK, 0));

            table.SetBorder(new SolidBorder(ColorConstants.BLACK, 0));

            table.AddCell(createTextCell(relatorio.GetDescrição()).SetFont(GetFont()).SetFontSize(10)
                .SetTextAlignment(TextAlignment.JUSTIFIED).SetPaddingTop(10)).SetBorder(new SolidBorder(ColorConstants.BLACK, 0));
            return table;
        }


        private Table GenerateEmitente()
        {
            //emitente 
            Table table = new Table(UnitValue.CreatePercentArray(new float[] { 3, 2 }));
            table.SetWidth(UnitValue.CreatePercentValue(100));
            Cell cell = new Cell();
            Paragraph EmitenteLine = new Paragraph().SetTextAlignment(TextAlignment.LEFT);
            Text pemitenteBold = new Text("Emitente: ").SetFont(GetFont(1)).SetFontSize(10)
                .SetTextAlignment(TextAlignment.LEFT);
            Text pemitente = new Text(relatorio.GetEmitente()).SetFont(GetFont()).SetFontSize(10)
                .SetTextAlignment(TextAlignment.LEFT);
            EmitenteLine.Add(pemitenteBold).Add(pemitente);

            //data
            Cell cellData = new Cell();
            Paragraph DataLine = new Paragraph().SetTextAlignment(TextAlignment.LEFT);
            Text DataBold = new Text("Data: ").SetFont(GetFont(1)).SetFontSize(10)
                .SetTextAlignment(TextAlignment.LEFT);
            Text data = new Text(relatorio.GetDate().ToString("dd/MM/yyyy")).SetFont(GetFont()).SetFontSize(10)
                .SetTextAlignment(TextAlignment.LEFT);
            DataLine.Add(DataBold).Add(data);








            cell.Add(EmitenteLine);
            cellData.Add(DataLine);
            //add and borders

            table.AddCell(cell).SetBorder(new SolidBorder(ColorConstants.BLACK, 0));
            table.AddCell(cellData).SetBorder(new SolidBorder(ColorConstants.BLACK, 0));
            table.SetBorder(new SolidBorder(ColorConstants.BLACK, 0));
            //.SetBorder(new SolidBorder(ColorConstants.BLACK, 0));
            return table;
        }



        /// <summary>
        /// generic information fields with small ammount of lines
        /// </summary>
        /// <returns></returns>
        private Table GenerateSingleLineFields()
        {
            //generate table
            Table table = new Table(UnitValue.CreatePercentArray(new float[] { 1 }));
            table.SetWidth(UnitValue.CreatePercentValue(100));

            //paragraph main
            Paragraph OrigemLine = new Paragraph().SetTextAlignment(TextAlignment.LEFT);

            Text pOrigemDesc = new Text("Origem: ").SetFont(GetFont(1)).SetFontSize(10)
                .SetTextAlignment(TextAlignment.LEFT);
            Text pOrigemDescText = new Text(relatorio.GetOrigem()).SetFont(GetFont()).SetFontSize(10)
                .SetTextAlignment(TextAlignment.LEFT);

            //adds to table and cell.
            OrigemLine.Add(pOrigemDesc).Add(pOrigemDescText);
            table.AddCell(OrigemLine);



            //paragraph main
            Paragraph TratamentoLine = new Paragraph().SetTextAlignment(TextAlignment.LEFT);
            Text pTratamentoDesc = new Text("Tratamento da não conformidade: ").SetFont(GetFont(1)).SetFontSize(10)
                .SetTextAlignment(TextAlignment.LEFT);
            Text pTratamentoText = new Text(relatorio.GetTratamento).SetFont(GetFont()).SetFontSize(10)
                .SetTextAlignment(TextAlignment.LEFT);

            //adds to table and cell.
            TratamentoLine.Add(pTratamentoDesc).Add(pTratamentoText);
            Cell cell = new Cell();
            cell.Add(TratamentoLine);
            table.AddCell(cell);

            /////// ---------------------------INVESTIÇÃO---------------------------
            ///
            ///
            ///
            table.AddCell(createTextCell("Investigação da(s) Causa(s)").SetPaddingTop(7).SetPaddingBottom(7).SetTextAlignment(TextAlignment.CENTER).SetFont(GetFont(1)).SetFontSize(10)).SetBorder(new SolidBorder(ColorConstants.BLACK, 0));

            table.SetBorder(new SolidBorder(ColorConstants.BLACK, 0));

            table.AddCell(createTextCell(relatorio.GetInvestigação())
                .SetFontSize(10).SetTextAlignment(TextAlignment.JUSTIFIED).SetPaddingTop(10)).SetBorder(new SolidBorder(ColorConstants.BLACK, 0));


            /////// ---------------------------DISPOSICAO---------------------------
            ///
            ///
            ///
            table.AddCell(createTextCell("Disposição").SetPaddingTop(7).SetPaddingBottom(7).SetTextAlignment(TextAlignment.CENTER).SetFont(GetFont(1)).SetFontSize(10)).SetBorder(new SolidBorder(ColorConstants.BLACK, 0));

            table.SetBorder(new SolidBorder(ColorConstants.BLACK, 0));

            table.AddCell(createTextCell(relatorio.GetDisposição)
                .SetFontSize(10).SetTextAlignment(TextAlignment.JUSTIFIED).SetPaddingTop(10)).SetBorder(new SolidBorder(ColorConstants.BLACK, 0)).SetKeepWithNext(false);



            return table;

        }



        /// <summary>
        /// handler for ações
        /// </summary>
        /// <param name="doc"></param>
        private void GenerateAções(Document doc)
        {
            if (relatorio.ReturnColecao() != null)
            {
                int numacao = 1;
                if (numacao == 1)
                {
                    Table table = new Table(new float[] { 10 });
                    table.SetKeepWithNext(true).SetKeepTogether(true);
                    table.UseAllAvailableWidth();
                    Cell cell = new Cell();
                    cell.Add(new Paragraph(String.Format("Ações")).SetPaddingTop(7).SetPaddingBottom(7)
                            .SetTextAlignment(TextAlignment.CENTER).SetFont(GetFont(1))).SetKeepTogether(true)
                        .SetKeepWithNext(true);
                    table.AddCell(cell).SetKeepWithNext(true);
                    //doc.Add(table);
                    Cell cell2 = new Cell();
                    cell2 = new Cell();
                    cell2.Add(new Paragraph(String.Format("Ação " + numacao.ToString("D2")))).SetPaddingTop(7)
                        .SetPaddingBottom(7).SetTextAlignment(TextAlignment.CENTER).SetFont(GetFont(1)).SetKeepTogether(true)
                        .SetKeepWithNext(true);
                    ;
                    table.AddCell(cell2);
                    doc.Add(table);
                    doc.Add(GenerateAcaoItem(relatorio.ReturnColecao().colecaoacaoitem[0]));
                    numacao++;
                }

                for (int i = 1; i < relatorio.ReturnColecao().colecaoacaoitem.Count; i++)
                {
                    Cell cell2 = new Cell();
                    Table table2 = new Table(new float[] { 1 });
                    table2.UseAllAvailableWidth().SetKeepTogether(true).SetKeepWithNext(true);
                    cell2 = new Cell();
                    cell2.Add(new Paragraph(String.Format("Ação " + numacao.ToString("D2")))).SetPaddingTop(7)
                        .SetPaddingBottom(7).SetTextAlignment(TextAlignment.CENTER).SetFont(GetFont(1)).SetKeepTogether(true)
                        .SetKeepWithNext(true);
                    ;
                    table2.AddCell(cell2).SetKeepWithNext(true).SetKeepTogether(true);
                    doc.Add(table2);
                    doc.Add(GenerateAcaoItem(relatorio.ReturnColecao().colecaoacaoitem[i]));
                    numacao++;
                }
            }
        }


        #endregion




        #region Creators


        private Table GenerateAcaoItem(acaoitem acao)
        {
            Table table = new Table(10);
            table.SetWidth(UnitValue.CreatePercentValue(100));

            Cell cell = new Cell(1, 8);


            cell.Add(new Paragraph("Descrição da Ação "));
            cell.Add(new Paragraph(acao.tipo));
            cell.SetFont(GetFont(1)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(10).SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell.SetKeepTogether(true).SetKeepTogether(true);
            table.AddCell(cell);





            Cell cell2 = new Cell(1, 2);
            cell2.Add(new Paragraph("Data de Implementação")).SetFont(GetFont(1)).SetTextAlignment(TextAlignment.CENTER).SetKeepTogether(true).SetKeepTogether(true); ;
            table.AddCell(cell2).SetKeepTogether(true).SetKeepTogether(true); ;
            Cell cell5 = new Cell(3, 8);
            cell5.Add(new Paragraph(acao.descricao)).SetFont(GetFont()).SetTextAlignment(TextAlignment.JUSTIFIED).SetKeepTogether(true).SetKeepTogether(true).SetFontSize(10); ;
            table.AddCell(cell5).SetKeepTogether(true).SetKeepTogether(true); ;

            Cell cell3 = new Cell(1, 1);
            cell3.Add(new Paragraph("Prevista")).SetKeepTogether(true).SetKeepTogether(true).SetFont(GetFont()).SetFontSize(10); 
            table.AddCell(cell3).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER);

            Cell cell4 = new Cell(1, 1);
            cell4.Add(new Paragraph("Realizada")).SetKeepTogether(true).SetKeepTogether(true).SetFont(GetFont()).SetFontSize(10); 
            table.AddCell(cell4).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER);

            //

            Cell cell6 = new Cell(2, 1);
            cell6.Add(new Paragraph(acao.prevista.ToString("dd/MM/yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetKeepTogether(true).SetKeepTogether(true).SetFontSize(10); ;
            table.AddCell(cell6);

            //first filter of below fields
            if (acao.realizada != DateTime.MinValue)
            {
                Cell cell7 = new Cell(2, 1);
                cell7.Add(new Paragraph(acao.realizada.ToString("dd/MM/yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetKeepTogether(true).SetKeepTogether(true).SetFontSize(10).SetFont(GetFont()); ;
                table.AddCell(cell7);

                Cell cell8 = new Cell(4, 8);
                cell8.Add(new Paragraph("Verificação da Eficácia das Ações Implementadas")).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetKeepTogether(true).SetKeepTogether(true).SetFontSize(10);
                table.AddCell(cell8).SetFont(GetFont()).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetFont(GetFont(1)).SetKeepTogether(true).SetKeepTogether(true).SetFontSize(10);


                Cell cell9 = new Cell(4, 8);
                Paragraph pPrevista = new Paragraph();
                Text t1 = new Text("Prevista para: ").SetFontSize(10).SetFont(GetFont(1));
                Text t2 = new Text(acao.previstapara.ToString("dd/MM/yyyy")).SetFontSize(10).SetFont(GetFont());
                pPrevista.Add(t1).Add(t2).SetTextAlignment(TextAlignment.CENTER);
                cell9.Add(pPrevista).SetKeepTogether(true).SetKeepTogether(true); ;
                table.AddCell(cell9);
                if (acao.verificadopor.Length > 2)
                {
                    Cell cell10 = new Cell(1, 8);
                    Paragraph verificadopor = new Paragraph();
                    Text t3 = new Text(String.Format("Vericicado por: ")).SetFontSize(10).SetFont(GetFont(1));
                    Text t4 = new Text(String.Format(acao.verificadopor)).SetFontSize(10).SetFont(GetFont());
                    verificadopor.Add(t3).Add(t4).SetTextAlignment(TextAlignment.JUSTIFIED);


                    cell10.Add(verificadopor).SetKeepTogether(true).SetKeepWithNext(true); ;
                    if (acao.eficaz)
                    {
                        Paragraph eficaz = new Paragraph("Eficacia: Ação foi eficaz").SetFontSize(10).SetFont(GetFont(1));
                        cell10.Add(eficaz).SetKeepTogether(true).SetKeepWithNext(true); ;
                    }
                    else
                    {
                        Paragraph eficaz = new Paragraph("Eficacia: Ação não foi eficaz").SetFontSize(10).SetFont(GetFont(1));
                        cell10.Add(eficaz).SetKeepTogether(true).SetKeepWithNext(true);
                    }
                    table.AddCell(cell10).SetTextAlignment(TextAlignment.JUSTIFIED);








                    //novo relatorio
                    Cell cell20 = new Cell(1, 2);
                    Paragraph eficazverificadoem = new Paragraph("Verificado em: \n" + acao.dataverificadopor.ToString("dd/MM/yyyy")).SetFontSize(10).SetFont(GetFont());
                    cell20.Add(eficazverificadoem).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    table.AddCell(cell20).SetKeepWithNext(false);

                    //novo relatorio

                    //Text textnovorelatorio = new Text("Aberto novo relatório?");


                    //Paragraph p = new Paragraph("Aberto novo relatório");
                    //cellNovoRelatorio.Add(p);

                    if (acao.abertonovorelatorio)
                    {
                        Cell cellNovoRelatorio = new Cell(1, 8);
                        Text textnovorelatorio = new Text("Aberto novo relatório? ").SetFontSize(10).SetFont(GetFont(1));
                        Text relatoriobool = new Text("Sim").SetFont(GetFont()).SetFontSize(10).SetFont(GetFont(0));
                        Paragraph pNovoRelatorio = new Paragraph();
                        pNovoRelatorio.Add(textnovorelatorio).Add(relatoriobool);

                        Text textNomeNovoRelatorioDesc = new Text("Novo Relatorio: ").SetFontSize(10).SetFont(GetFont(1));
                        Text textNomeNovoRelatorionome = new Text(acao.novorelatorio).SetFontSize(10).SetFont(GetFont(0));
                        Paragraph pNomeNovoRelatorio = new Paragraph();
                        pNomeNovoRelatorio.Add(textNomeNovoRelatorioDesc).Add(textNomeNovoRelatorionome);
                        cellNovoRelatorio.Add(pNovoRelatorio).Add(pNomeNovoRelatorio);

                        Cell cellDataNovoRelatorio = new Cell(1, 2);
                        Paragraph pDataNovoRelatorio = new Paragraph("Aberto em: \n" + acao.datanovorelatorio.ToString("dd/MM/yyyy"));
                        cellDataNovoRelatorio.Add(pDataNovoRelatorio).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER);
                        //Paragraph p3 = new Paragraph(acao.datanovorelatorio.ToString("dd/MM/yyyy"));
                        //Paragraph p4 = new Paragraph("Relatorio nº: " + acao.novorelatorio);
                        table.AddCell(cellNovoRelatorio).AddCell(cellDataNovoRelatorio);

                    }
                    else
                    {
                        Cell cellNovoRelatorio = new Cell(1, 10);
                        Text textnovorelatorio = new Text("Aberto novo relatório? ").SetFont(GetFont(1));
                        Text relatoriobool = new Text("Não").SetFont(GetFont());
                        Paragraph pNovoRelatorio = new Paragraph();
                        pNovoRelatorio.Add(textnovorelatorio).Add(relatoriobool);
                        cellNovoRelatorio.Add(pNovoRelatorio);
                        table.AddCell(cellNovoRelatorio);
                    }

                }


            }
            else
            {
                //Cell cell7 = new Cell(2, 1);
                //table.AddCell(cell7).SetKeepTogether(true).SetKeepTogether(true); 
                //table.AddCell(cell7);


                Cell cell7 = new Cell(2, 1);
                cell7.Add(new Paragraph("-")).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetKeepTogether(true).SetKeepTogether(true); ;
                table.AddCell(cell7);
            }




            if (acao.observacoes.Length > 0)
            {
                //observação
                Cell cell23 = new Cell(1, 10);
                Paragraph pObservaçãoTitle = new Paragraph("Observação").SetFont(GetFont(1));
                Paragraph pObservaçãoText = new Paragraph(acao.observacoes).SetFont(GetFont());
                cell23.Add(pObservaçãoTitle).Add(pObservaçãoText);
                table.AddCell(cell23);
            }




            return table;
        }
        private static Cell createImageCell(String path)
        {
            Image img = new Image(ImageDataFactory.Create(path));
            img.SetWidth(UnitValue.CreatePercentValue(75));
            Cell cell = new Cell(1, 1).Add(img);
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
            else if (font == 1)
            {
                return PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
            }
            else
            {
                return PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLDOBLIQUE);
            }




        }
        private Cell getCell(int rowspawn, int columnspan)
        {
            Cell cell = new Cell(1, columnspan);
            return cell;
        }
        private Cell getCell(int cm, string text)
        {
            Cell cell = new Cell(1, cm);
            Paragraph p = new Paragraph(
                String.Format("%smm", 10 * cm)).SetFontSize(8);
            p.SetTextAlignment(TextAlignment.CENTER);
            cell.Add(p);
            return cell;
        }
        private Cell getCell(int cm, Text text)
        {
            Cell cell = new Cell(1, cm);
            Paragraph p = new Paragraph(
                String.Format("%smm", 10 * cm)).SetFontSize(8);
            p.SetTextAlignment(TextAlignment.CENTER);
            cell.Add(p);
            return cell;
        }
        #endregion
    }
}
