using School.DataAccess;
using School.DataModel;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Helpers
{
    public class PrintFunction
    {
        private List<Stream> m_Streams { get; set; }

        private int m_CurrentPageIndex { get; set; }

        private Stream CreateStream(string p_Name,string p_FileNameExtension, Encoding p_Encoding,string p_MimeType, bool p_WillSeek)
        {
            Stream _Stream = new MemoryStream();
            m_Streams.Add(_Stream);
            return _Stream;
        }

        public void Export(LocalReport p_Report)
        {
            string _DeviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.25in</MarginLeft>
                <MarginRight>0.25in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
            </DeviceInfo>";

            PrintSettingService _PrintSettingService = new PrintSettingService();

            Result<PrintSettingMaster> _Result = _PrintSettingService.GetPrintSetting(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                if (_Result.Data != null)
                {
                    _DeviceInfo =
                        @"<DeviceInfo>
                        <OutputFormat>" + _Result.Data.OutPutFormat + "</OutputFormat>" +
                          "<PageWidth>" + _Result.Data.PageWidth + "in</PageWidth>" +
                          "<PageHeight>" + _Result.Data.PageHeight + "in</PageHeight>" +
                          "<MarginTop>" + _Result.Data.MarginTop + "in</MarginTop>" +
                          "<MarginLeft>" + _Result.Data.MarginLeft + "in</MarginLeft>" +
                          "<MarginRight>" + _Result.Data.MarginRight + "in</MarginRight>" +
                          "<MarginBottom>" + _Result.Data.MarginBottom + "in</MarginBottom>" +
                          "</DeviceInfo>";
                }
            }

            Warning[] _Warnings;
            m_Streams = new List<Stream>();
            p_Report.Render("Image", _DeviceInfo, CreateStream,
               out _Warnings);
            foreach (Stream stream in m_Streams)
                stream.Position = 0;
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile _PageImage = new
               Metafile(m_Streams[m_CurrentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle _AdjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, _AdjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(_PageImage, _AdjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_CurrentPageIndex++;
            ev.HasMorePages = (m_CurrentPageIndex < m_Streams.Count);
        }

        public void Print()
        {
            if (m_Streams == null || m_Streams.Count == 0)
                throw new Exception("Error: no stream to print.");

            PrintDocument _PrintDoc = new PrintDocument();

            if (!_PrintDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                _PrintDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_CurrentPageIndex = 0;
                _PrintDoc.Print();
            }
        }
    }
}
