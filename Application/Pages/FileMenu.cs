using NathansSpecflowDesktopFramework.Application.Elements;

namespace NathansSpecflowDesktopFramework.Application.Pages
{
    public class FileMenu
    {
        private readonly IWebDriver driver;
        private static string randomFileName = Path.Combine(Path.GetRandomFileName());

        public FileMenu(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ElementWrapper Dropdown => new(driver, By.Name("OneDrive - ROQ IT"));
        public ElementWrapper DownloadsOption => new(driver, By.Name("Downloads (pinned)"));
        public ElementWrapper EnterFileNameInput => new(driver, By.Name("Enter file name here"));
        public ElementWrapper FileTabButton => new(driver, By.Name("File Tab"));
        public ElementWrapper GetFileName => new(driver, By.Name($"{randomFileName}.docx"));
        public ElementWrapper PdfOption => new(driver, By.Name("PDF (*.pdf)"));
        public ElementWrapper SaveAsButton => new(driver, By.Name("Save As"));
        public ElementWrapper SaveAsType => new(driver, By.Name("Save as type"));
        public ElementWrapper SaveOption => new(driver, By.Name("Save"));

        public void ClickDownloadsOption()
        {
            DownloadsOption.WaitForElement();
            DownloadsOption.Click();
        }

        public void ClickDropdown()
        {
            Dropdown.Click();
            DownloadsOption.WaitUntilExists();
        }

        public void ClickFileTabButton()
        {
            FileTabButton.Click();
        }
        public void ClickSave()
        {
            SaveOption.Click();
        }

        public void ClickSaveAsButton()
        {
            SaveAsButton.Click();
        }

        public void ClickSaveAsType()
        {
            SaveAsType.Click();
        }

        public void ClickPdfOption()
        {
            PdfOption.WaitForElement();
            PdfOption.Click();
        }

        public void EnterFileName()
        {
            EnterFileNameInput.SendKeys(randomFileName);
        }

        public static string ReturnFileName()
        {
            return randomFileName;
        }

        public void SaveAFileWithRandomName()
        {
            ClickFileTabButton();
            ClickSaveAsButton();
            EnterFileName();
            ClickDropdown();          
            ClickDownloadsOption();
            ClickSave();
            FileTabButton.WaitUntilExists();

        }

        public void SavePDFDocumentToDesktop()
        {
            ClickFileTabButton();
            ClickSaveAsButton();
            EnterFileName();
            ClickSaveAsType();
            ClickPdfOption();
            ClickDropdown();
            ClickDownloadsOption();
            ClickSave();
            FileTabButton.WaitUntilExists();
        }
    }
}
