using School.Common;
using School.DataAccess;
using School.DataModel;
using School.Helpers;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.UI.Report
{
    public partial class frmReport : Form
    {
        #region Variables

        private ReceiptService _ReceiptService = new ReceiptService();

        #endregion

        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            this.rvReport.RefreshReport();

            //Result<DataTable> _Result = _CollectFeesService.GetFeesReceiptByReceiptNo(3,Convert.ToString(Properties.Settings.Default.Year));

            //if (_Result.IsSuccess)
            //{
            //    rvReport.LocalReport.ReportEmbeddedResource = "School.UI.Report.FeesReceipt.rdlc";

            //    rvReport.LocalReport.DataSources.Add(new ReportDataSource("DataSet", _Result.Data));

            //    rvReport.RefreshReport();

            //    //rvReport.RenderingComplete += new RenderingCompleteEventHandler(reportViewer_RenderingComplete);

            //    //LocalReport report = new LocalReport();
            //    //report.ReportEmbeddedResource = "School.UI.Report.FeesReceipt.rdlc";
            //    //report.DataSources.Add(
            //    //   new ReportDataSource("DataSet", _Result.Data));
            //    //Export(report);
            //    //Print();
            //}
        }

        void reportViewer_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            rvReport.PrintDialog();
        }

        List<Stream> m_streams { get; set; }

        int m_currentPageIndex { get; set; }

        private Stream CreateStream(string name,
     string fileNameExtension, Encoding encoding,
     string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.25in</MarginLeft>
                <MarginRight>0.25in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Result<DataTable> _Result = _ReceiptService.GetFeesReceiptByReceiptNo(Convert.ToInt64(textBox1.Text), Convert.ToString(Properties.Settings.Default.Year));

                if (_Result.IsSuccess)
                {
                    rvReport.LocalReport.ReportEmbeddedResource = "School.UI.Report.FeesReceipt.rdlc";

                    rvReport.LocalReport.DataSources.Add(new ReportDataSource("DataSet", _Result.Data));

                    rvReport.RefreshReport();

                    rvReport.RenderingComplete += new RenderingCompleteEventHandler(reportViewer_RenderingComplete);

                    //LocalReport report = new LocalReport();
                    //report.ReportEmbeddedResource = "School.UI.Report.FeesReceipt.rdlc";
                    //report.DataSources.Add(
                    //   new ReportDataSource("DataSet", _Result.Data));

                    //PrintFunction _PrintFunction = new PrintFunction();

                    //_PrintFunction.Export(report);
                    //_PrintFunction.Print();
                }

            }
            catch (Exception _Exception)
            {
                throw _Exception;
            }
        }

    }
}
