using System.Drawing.Printing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;

namespace NeoCobranza.ViewModels
{
    public class PdfPrintPageEventHandler
    {
        private PdfReader _reader;
        private int _currentPage;

        public PdfPrintPageEventHandler(PdfReader reader)
        {
            _reader = reader;
            _currentPage = 1;
        }

        public void PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_currentPage <= _reader.NumberOfPages)
            {
                // Obtener la página PDF actual
                PdfDictionary pageDict = _reader.GetPageN(_currentPage);
                Rectangle pageSize = _reader.GetPageSizeWithRotation(_currentPage);
                //e.Graphics.DrawImage(PdfReader.GetPdfPageImage(pageDict), e.MarginBounds);

                // Incrementar el número de página
                _currentPage++;
                e.HasMorePages = _currentPage <= _reader.NumberOfPages;
            }
            else
            {
                e.HasMorePages = false;
            }
        }
    }
}
