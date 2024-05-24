using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.Text;

namespace NathansSpecflowDesktopFramework.Application.Pages
{
    public class NewPDF
    {
        private readonly IWebDriver driver;
        private string fileName;

        public NewPDF(IWebDriver driver)
        {
            this.driver = driver;
            fileName = FileMenu.ReturnFileName();
        }

        public string ExtractTextFromPDF()
        {
            string filePath = $@"C:\Users\nathan.shaughnessy\Downloads\{fileName}.pdf";
            StringBuilder textBuilder = new StringBuilder();

            using (PdfReader reader = new PdfReader(filePath))
            {
                using (PdfDocument pdfDocument = new PdfDocument(reader))
                {
                    PdfPage pdfPage = pdfDocument.GetPage(1);
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string text = PdfTextExtractor.GetTextFromPage(pdfPage, strategy);
                    textBuilder.Append(text);
                }
            }

            string extractedText = textBuilder.ToString().Trim().Replace("\n", "");
            return extractedText;
        }
    }
}
