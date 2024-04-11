using NathansSpecflowDesktopFramework.Application.Elements;
using OpenQA.Selenium;

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

        public ElementWrapper FileTabButton => new ElementWrapper(driver, By.Name("File Tab"));
        public ElementWrapper SaveAsButton => new ElementWrapper(driver, By.Name("Save As"));
        public ElementWrapper EnterFileNameInput => new ElementWrapper(driver, By.Name("Enter file name here"));
        public ElementWrapper Dropdown => new ElementWrapper(driver, By.Name("OneDrive - ROQ IT"));
        public ElementWrapper DownloadsOption => new ElementWrapper(driver, By.Name("Downloads (pinned)"));
        public ElementWrapper SaveOption => new ElementWrapper(driver, By.Name("Save"));
        public ElementWrapper SaveAsType => new ElementWrapper(driver, By.Name("Save as type"));
        public ElementWrapper PdfOption => new ElementWrapper(driver, By.Name("PDF (*.pdf)"));
        public ElementWrapper GetFileName => new ElementWrapper(driver, By.Name($"{randomFileName}.docx"));     

        public void ClickFileTabButton()
        {
            FileTabButton.Click();
        }

        public void ClickSaveAsButton()
        {
            SaveAsButton.Click();
        }

        public void EnterFileName()
        {
            EnterFileNameInput.SendKeys(randomFileName);
        }

        public void ClickDropdown()
        {
            Dropdown.Click();
        }

        public void ClickDownloadsOption() 
        { 
            DownloadsOption.Click();
        }

        public void ClickSave() 
        { 
            SaveOption.Click();
        }

        public void ClickSaveAsType()
        {
            SaveAsType.Click();
        }

        public void ClickPdfOption()
        {
            PdfOption.Click();
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
            Thread.Sleep(3000);
            ClickDownloadsOption();
            ClickSave();
            Thread.Sleep(5000);
        }

        public void SavePDFDocumentToDesktop()
        {
            ClickFileTabButton();
            ClickSaveAsButton();
            EnterFileName();
            ClickSaveAsType();
            ClickPdfOption();
            ClickDropdown();
            Thread.Sleep(3000);
            ClickDownloadsOption();
            ClickSave();
            Thread.Sleep(5000);
        }
    }
}
